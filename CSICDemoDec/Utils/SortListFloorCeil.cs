using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSICDemoDec.Utils
{
    public class SortedListWithFloorAndCeilingIntegerKey<TV> : SortedList<Int32, TV>
    {
        #region Floor object methods

        public int FloorIndexFor(Int32 searchKey)
        {
            RaiseExceptionIfListIsEmpty();

            // If the lowest value is higher than the search key, then there is no floor value possible.
            if (Keys[0] > searchKey)
            {
                throw new ArgumentOutOfRangeException("No floor value exists. Lowest key value is higher than search key value.");
            }

            // If the search key value exists as an exact match, return its index.
            if (ContainsKey(searchKey))
            {
                return Keys.IndexOf(searchKey);
            }

            // If the search key value is greater than the highest value, then the highest value is the floor value.
            if (Keys[Count - 1] < searchKey)
            {
                return (Count - 1);
            }

            // There weren't any short-circuit solutions, so do the search.
            return FindFloorObjectIndex(searchKey);
        }

        public Int32 FloorKeyFor(Int32 searchKey)
        {
            return Keys[FloorIndexFor(searchKey)];
        }

        public TV FloorValueFor(Int32 searchKey)
        {
            return Values[FloorIndexFor(searchKey)];
        }

        #endregion

        #region Ceiling object methods

        public int CeilingIndexFor(Int32 searchKey)
        {
            RaiseExceptionIfListIsEmpty();

            // If the highest value is lower than the search key, then there is no ceiling value possible.
            if (Keys[Count - 1] < searchKey)
            {
                throw new ArgumentOutOfRangeException("No ceiling value exists. Highest key value is lower than search key value.");
            }

            // If the search key value exists as an exact match, return it.
            if (ContainsKey(searchKey))
            {
                return Keys.IndexOf(searchKey);
            }

            // If the search key value is lower than the lowest value, then the lowest value is the ceiling value.
            if (Keys[0] > searchKey)
            {
                return 0;
            }

            // There weren't any short-circuit solutions, so do the search.
            return (FindFloorObjectIndex(searchKey) + 1);
        }

        public Int32 CeilingKeyFor(Int32 searchKey)
        {
            return Keys[CeilingIndexFor(searchKey)];
        }

        public TV CeilingValueFor(Int32 searchKey)
        {
            return Values[CeilingIndexFor(searchKey)];
        }

        #endregion

        #region Private methods

        private void RaiseExceptionIfListIsEmpty()
        {
            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException("List does not contain any values.");
            }
        }

        private int FindFloorObjectIndex(double searchKey)
        {
            int lowIndex = 0;
            int highIndex = Count;
            int midIndex = lowIndex + ((highIndex - lowIndex) / 2);

            bool continueSearching = true;

            while (continueSearching)
            {
                midIndex = lowIndex + ((highIndex - lowIndex) / 2);

                if ((midIndex == lowIndex) || (midIndex == highIndex))
                {
                    continueSearching = false;
                }
                else if (Keys[midIndex] < searchKey)
                {
                    lowIndex = midIndex;
                }
                else
                {
                    highIndex = midIndex;
                }
            }

            return midIndex;
        }

        #endregion
    }//class
}//namespace