﻿using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using Xunit;

namespace HttpContextNSubstitute.Tests
{
    public class HeaderDictionaryMockTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void HeaderDictionaryMock_WhenRun_AssertTrue(UnitTest<HeaderDictionaryMock> unitTest)
        {
            unitTest.Run(() => new HeaderDictionaryMock());
        }

        public static IEnumerable<object[]> Data =>
            new UnitTest<HeaderDictionaryMock>[]
            {
                //Class
                new ContextMockUnitTest<HeaderDictionaryMock, IHeaderDictionary>(),
                //Properties
                new PropertyGetSetUnitTest<HeaderDictionaryMock, IHeaderDictionary, StringValues>(
                    t => t[Fakes.String],
                    t => t[Fakes.String] = Fakes.StringValues
                ),
                new PropertyGetSetUnitTest<HeaderDictionaryMock, IHeaderDictionary, long?>(
                    t => t.ContentLength,
                    t => t.ContentLength = Fakes.Long
                ),
                new PropertyGetUnitTest<HeaderDictionaryMock, IHeaderDictionary, ICollection<string>>(
                    t => t.Keys
                ),
                new PropertyGetUnitTest<HeaderDictionaryMock, IHeaderDictionary, ICollection<StringValues>>(
                    t => t.Values
                ),
                new PropertyGetUnitTest<HeaderDictionaryMock, IHeaderDictionary, int>(
                    t => t.Count
                ),
                new PropertyGetUnitTest<HeaderDictionaryMock, IHeaderDictionary, bool>(
                    t => t.IsReadOnly
                ),
                //Methods
                new MethodInvokeUnitTest<HeaderDictionaryMock, IHeaderDictionary>(
                    t => t.Add(Fakes.String, Fakes.StringValues)
                ),
                new MethodInvokeUnitTest<HeaderDictionaryMock, IHeaderDictionary>(
                    t => t.Add(Arg.Any<KeyValuePair<string, StringValues>>())
                ),
                new MethodInvokeUnitTest<HeaderDictionaryMock, IHeaderDictionary>(
                    t => t.Clear()
                ),
                new MethodInvokeUnitTest<HeaderDictionaryMock, IHeaderDictionary>(
                    t => t.Contains(Arg.Any<KeyValuePair<string, StringValues>>())
                ),
                new MethodInvokeUnitTest<HeaderDictionaryMock, IHeaderDictionary>(
                    t => t.ContainsKey(Fakes.String)
                ),
                new MethodInvokeUnitTest<HeaderDictionaryMock, IHeaderDictionary>(
                    t => t.CopyTo(Arg.Any < KeyValuePair < string, StringValues >[] >(), Fakes.Int)
                ),
                new MethodInvokeUnitTest<HeaderDictionaryMock, IHeaderDictionary>(
                    t => t.GetEnumerator()
                ),
                new ActionAndAssertUnitTest<HeaderDictionaryMock>(
                    t => ((IEnumerable)t).GetEnumerator(),
                    t => t.Mock.As<IEnumerable>().Received(1).GetEnumerator()
                ),
                new MethodInvokeUnitTest<HeaderDictionaryMock, IHeaderDictionary>(
                    t => t.Remove(Fakes.String)
                ),
                new MethodInvokeUnitTest<HeaderDictionaryMock, IHeaderDictionary>(
                    t => t.Remove(Arg.Any < KeyValuePair < string, StringValues > >())
                ),
                new MethodInvokeUnitTest<HeaderDictionaryMock, IHeaderDictionary>(
                    t => t.TryGetValue(Fakes.String, out Fakes.OutStringValues)
                ),
            }.ToData();
    }
}
