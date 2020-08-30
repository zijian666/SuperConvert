﻿using System.Collections.Generic;
using zijian666.SuperConvert.Convertor;
using zijian666.SuperConvert.Core;
using zijian666.SuperConvert.Interface;

namespace zijian666.SuperConvert.Factory
{
    public class EnumConvertorFactory : IConvertorFactory
    {
        public IEnumerable<MatchedConvertor<T>> Create<T>()
        {
            if (typeof(T).IsEnum)
            {
                yield return new MatchedConvertor<T>(new EnumConvertor<T>(), 1, MacthedLevel.Full);
            }
        }
    }
}
