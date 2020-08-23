﻿using System;
using System.Linq;
using zijian666.SuperConvert.Convertor.Base;
using zijian666.SuperConvert.Interface;

namespace zijian666.SuperConvert.Core
{
    public class ConvertorBuilder
    {
        private readonly IConvertorFactory[] _factories;

        public ConvertorBuilder(IConvertorFactory[] factories)
        {
            if (factories is null || factories.Length == 0)
            {
                throw new ArgumentNullException(nameof(factories));
            }
            _factories = factories;
        }
        public IConvertor<T> Build<T>()
        {
            var convs = _factories
                .SelectMany(x => x.Create<T>())
                .Where(x => x != null)
                .OrderBy(x => x)
                .Select(x => new TraceConvertor<T>(x.Convertor));

            if (convs.Count() == 1)
            {
                return convs.FirstOrDefault();
            }

            return new TraceConvertor<T>(new AggregateConvertor<T>(convs));
        }
    }
}