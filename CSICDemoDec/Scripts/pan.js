 
var COREHTML5 = COREHTML5 || { };

// Constructor........................................................

COREHTML5.Pan = function (imageCanvas, mainimage, thumbimage, myMessage, folder, message) {
   var self = this;
   this.message = message; 
   // Store arguments in member variables
   this.folder = folder;
   this.imageCanvas = imageCanvas; 
   this.Singleton = false;
   this.MainImage = mainimage;
   this.thumbImage = thumbimage;
   this.panCanvasAlpha = 65 || 0.5;
   this.imageContext = imageCanvas.getContext('2d');

   var jsonData = JSON.parse(myMessage);
   this.mappoints = new Array(jsonData.counters.length);
   this.mapPin = new Array(jsonData.counters.length);
   var counter; var pin;
   for (var i = 0; i < jsonData.counters.length; i++)
   {
           var counter = jsonData.counters[i];
           this.mapPin[i] = new Image();
           this.mapPin[i].src = this.folder + counter.counter_Img;
           this.mappoints[i] = counter;
           //console.log(counter.counter_name);
           //console.log(counter.counter_X);
           //console.log(counter.counter_Y);
           //console.log(this.mapPin[i].src);

    }
   // Get a reference to the image canvas's context,
   // and create the pan canvas and the DOM element.
   // Put the pan canvas in the DOM element.
   
   this.panCanvas = document.createElement('canvas');
   this.panContext = this.panCanvas.getContext('2d');
     


   this.domElement = document.createElement('div');
   this.domElement.appendChild(this.panCanvas);

   // If the image is not loaded, initialize when the image loads;
   // otherwise, initialize now.
   
   if (this.thumbImage.width == 0 || this.thumbImage == 0 || this.thumbImage.height == 0) { // image not loaded
       this.thumbImage.onload = function (e) {
           self.initialize();
       };
   }
   else {
       this.initialize();
   }
   if (this.MainImage.width == 0 || this.MainImage == 0 || this.MainImage.height==0) { // image not loaded
       this.MainImage.onload = function (e) {
         self.initialize();
      };
   }
   else {
      this.initialize();
   }
   return this;
};

// Prototype..........................................................

COREHTML5.Pan.prototype = { 
    initialize: function () {

        if ((this.MainImage != 0)) {
            if ((this.thumbimage != 0)) {
                if (this.Singleton == false) {
                    var height = this.MainImage.height * (this.thumbImage.height / this.MainImage.height);  
                    var width = this.MainImage.width * (this.thumbImage.width / this.MainImage.width); 

                    this.mappoints[0].counter_X = this.imageCanvas.width / 2;
                    this.mappoints[0].counter_Y = this.imageCanvas.height / 2;
                    this.addEventHandlers();
                    this.setupViewport(width, height);
                    this.setupDOMElement(width, height);
                    this.setupPanCanvas(width, height);
                    this.draw();
                } else {

                    console.log("Passed Main Imag passed thumb, failed singleton");
                }

            } else 
            {
                console.log("Passed Main Imag failed thumb");
            }

        }
        else
        {
            console.log("failed Main Imag not tested others");
        }
   },

    setupPanCanvas: function (w, h) {
        this.panCanvas.width = w;
        this.panCanvas.height = h;
    },

   setupDOMElement: function (w, h)  {
      this.domElement.style.width = w + 'px';
      this.domElement.style.height = h + 'px';
      this.domElement.className = 'pan';
   },
   
   setupViewport: function (w, h) {
      this.viewportLocation = { x: 0, y: 0 };
      this.viewportSize = { width: 50, height: 50 };
      this.viewportLastLocation =  { x: 0, y: 0 };

      this.viewportSize.width = this.imageCanvas.width * (this.thumbImage.width / this.MainImage.width);

      this.viewportSize.height = this.imageCanvas.height * (this.thumbImage.height / this.MainImage.height);
   },

   moveViewport: function(mouse, offset) {
      this.viewportLocation.x = mouse.x - offset.x;
      this.viewportLocation.y = mouse.y - offset.y;

       var delta = {
         x: this.viewportLastLocation.x - this.viewportLocation.x,
         y: this.viewportLastLocation.y - this.viewportLocation.y
      };

      this.imageContext.translate(
         delta.x * (this.MainImage.width / this.panCanvas.width),
         delta.y * (this.MainImage.height / this.panCanvas.height));
    //  pan.mappoints[0].counter_X = delta.x * (this.MainImage.width / this.panCanvas.width) * (pan.mappoints[0].counter_X);
   //   pan.mappoints[0].counter_Y = delta.y * (this.MainImage.width / this.panCanvas.width) * (pan.mappoints[0].counter_X);

       //pan.message.innerHTML = 'lo:' + (this.viewportLocation.x) + ',' + (this.viewportLocation.y);
      pan.message.innerHTML = 'lo:' + (delta.x * (this.MainImage.width / this.panCanvas.width) * (pan.mappoints[0].counter_X))
                                    + ','
                                    + (delta.y * (this.MainImage.width / this.panCanvas.width) * (pan.mappoints[0].counter_Y));

      this.viewportLastLocation.x = this.viewportLocation.x;
      this.viewportLastLocation.y = this.viewportLocation.y;
   },

   isPointInViewport: function (x, y) {
      this.panContext.beginPath();
      this.panContext.rect(this.viewportLocation.x,
                          this.viewportLocation.y,
                          this.viewportSize.width,
                          this.viewportSize.height);

      return this.panContext.isPointInPath(x, y);
   },

    writeMessage:function(canvas, message) {
        var context = canvas.getContext('2d');
            context.clearRect(0, 0, canvas.width, canvas.height);
            context.font = '12pt Calibri';
            context.fillStyle = 'black';
            context.fillText(message, 10, 25);
    },
    getMousePos:function(canvas, evt) {
        var rect = canvas.getBoundingClientRect();
        return {
            x: evt.clientX - rect.left,
            y: evt.clientY - rect.top
        };
    }, 
   addEventHandlers: function() {
      var pan = this;
      pan.imageCanvas.addEventListener('mousemove', function (evt) {
            var mousePos = pan.getMousePos(pan.imageCanvas, evt);
            var message = 'Mouse position: ' + (mousePos.x ) + ',' + (mousePos.y);
            //pan.message.innerHTML = message;
            //pan.writeMessage(pan.imageCanvas, message);
            }, false);
      pan.domElement.onmousedown = function(e) {
         var mouse = pan.windowToCanvas(e.clientX, e.clientY),
             offset = null; 
         
         e.preventDefault();


         if (pan.isPointInViewport(mouse.x, mouse.y)) {
            offset = { x: mouse.x - pan.viewportLocation.x,
                       y: mouse.y - pan.viewportLocation.y };
            //console.log("offset:" + offset.x + ":" + offset.y)
            pan.panCanvas.onmousemove = function(e) {
               pan.erase(); 
               pan.moveViewport(
                  pan.windowToCanvas(e.clientX, e.clientY), offset);

               pan.draw();
            };

            pan.panCanvas.onmouseup = function(e) {
               pan.panCanvas.onmousemove = undefined;
               pan.panCanvas.onmouseup = undefined;
            };
         }
      };
   },
   hitTest:function(i, mx, my) {
                // get middle of image
                var x = this.mappoints[i].counter_X + (this.mapPin[i].width / 2);
            var y = this.mappoints[i].counter_Y + (this.mapPin[i].height / 2);

            var dx;
            var dy;
            dx = mx - x;
            dy = my - y;

            //a "hit" will be registered if the distance away from the center is less than the radius of the circular object		
            return (dx * dx + dy * dy < (this.mapPin[i].width / 2) * (this.mapPin[i].width / 2));
    },
   erase: function() {
      this.panContext.clearRect(0,0,
                      this.panContext.canvas.width,
                      this.panContext.canvas.height);
   },

   drawPanCanvas: function(alpha) {
      this.panContext.save();
      this.panContext.globalAlpha = alpha;
      this.panContext.drawImage(this.thumbImage,
                                0, 0,
                                this.thumbImage.width,
                                this.thumbImage.height,
                                0, 0,
                                this.panCanvas.width,
                                this.panCanvas.height);
      this.panContext.restore();
   },

   drawImageCanvas: function() {


       this.imageContext.drawImage(this.MainImage,
                                  0, 0,
                                  this.MainImage.width,
                                  this.MainImage.height);
       for(var i=0; i<this.mapPin.length;i++)
       {
           this.imageContext.drawImage(this.mapPin[i], this.mappoints[i].counter_X, this.mappoints[i].counter_Y, this.mapPin[i].width, this.mapPin[i].height);
            console.log(this.mapPin[i].src+ ":"+this.mappoints[i].counter_X+":"+ this.mappoints[i].counter_Y+":"+this.mapPin[i].width+":"+ this.mapPin[i].height+":");
           this.imageContext.textAlign = "center";
           this.imageContext.fillText(this.mappoints[i].counter_name + ":" + this.mappoints[i].counter_Txt, this.mappoints[i].counter_X, this.mappoints[i].counter_Y );
       }
   },

  drawViewport: function () {
      this.panContext.shadowColor = 'rgba(0,0,0,0.4)';
      this.panContext.shadowOffsetX = 2;
      this.panContext.shadowOffsetY = 2;
      this.panContext.shadowBlur = 3;

      this.panContext.lineWidth = 5;
      this.panContext.strokeStyle = 'red';
      this.panContext.strokeRect(this.viewportLocation.x,
                                 this.viewportLocation.y, 
                                 this.viewportSize.width,
                                 this.viewportSize.height);
   },

   clipToViewport: function() {
      this.panContext.beginPath();
      this.panContext.rect(this.viewportLocation.x,
                           this.viewportLocation.y,
                           this.viewportSize.width, 
                           this.viewportSize.height);
      this.panContext.clip();
   },
   
   draw: function() {
      this.drawImageCanvas();
      this.drawPanCanvas(this.panCanvasAlpha);

      this.panContext.save();
      this.clipToViewport();
      this.drawPanCanvas(1.0);
      this.panContext.restore();

      this.drawViewport();
  },
   
   windowToCanvas: function (x, y)
   {
      var bbox = this.panCanvas.getBoundingClientRect();

      return {
         x: x - bbox.left * (this.panCanvas.width  / bbox.width),
         y: y - bbox.top  * (this.panCanvas.height / bbox.height)
      };
   },
};
