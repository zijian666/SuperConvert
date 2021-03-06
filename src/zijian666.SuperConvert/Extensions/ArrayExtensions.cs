﻿using System;
using System.Collections;

namespace zijian666.SuperConvert.Extensions
{
    static class ArrayExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static byte[] Slice(this byte[] bytes, int size)
        {
            if (bytes == null || size <= 0)
            {
                return new byte[size];
            }
            if (bytes.Length == size)
            {
                return bytes;
            }
            var bs = new byte[size];
            Array.Copy(bytes, 0, bs, 0, size);
            return bs;
        }

        public static T TryReset<T>(this T enumerator)
            where T : IEnumerator
        {
            try
            {
                enumerator?.Reset();
                return enumerator;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
