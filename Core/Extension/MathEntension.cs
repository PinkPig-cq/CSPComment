using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extension
{
    public static class MathEntension
    {
        /// <summary>
        /// 向下取整
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int IntFloor(this float source)
        {
            return (int)Math.Floor(source);
        }

        /// <summary>
        /// 向上取整
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int IntCeiling(this float source)
        {
            return (int)Math.Ceiling(source);
        }
    }
}
