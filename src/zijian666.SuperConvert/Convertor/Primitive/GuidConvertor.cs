﻿using zijian666.SuperConvert.Extensions;
using zijian666.SuperConvert.Convertor.Base;
using zijian666.SuperConvert.Core;
using zijian666.SuperConvert.Interface;
using System;

namespace zijian666.SuperConvert.Convertor
{
    /// <summary>
    /// <seealso cref="Guid" /> 转换器
    /// </summary>
    public class GuidConvertor : BaseConvertor<Guid>, IFrom<string, Guid>, IFrom<byte[], Guid>, IFrom<decimal, Guid>
    {
        public ConvertResult<Guid> From(IConvertContext context, string input)
        {
            if (input.Length == 0)
            {
                return Exceptions.ConvertFail(input, TypeFriendlyName, context.Settings.CultureInfo);
            }
            if (Guid.TryParse(input, out var result))
            {
                return result;
            }
            return Exceptions.ConvertFail(input, TypeFriendlyName, context.Settings.CultureInfo);
        }

        public ConvertResult<Guid> From(IConvertContext context, decimal input)
        {
            var arr = decimal.GetBits(input);
            var bytes = new byte[16];
            Buffer.BlockCopy(arr, 0, bytes, 0, 16);
            return new Guid(bytes);
        }

        public ConvertResult<Guid> From(IConvertContext context, byte[] input)
        {
            if (input?.Length == 16)
            {
                return new Guid(input);
            }
            return Exceptions.ConvertFail(input, TypeFriendlyName, context.Settings.CultureInfo);
        }
    }
}