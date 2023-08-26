﻿using System;
using HttpContextMoq.Generic;
using HttpContextMoq.Tests.Helpers;
using HttpContextMoq.Tests.Utils;

namespace HttpContextMoq.Tests
{
    public class PropertySetUnitTest<TContextMock, TContext> : UnitTest<TContextMock>
        where TContext : class
        where TContextMock : class, IContextMock<TContext>, TContext
    {
        private readonly Action<TContext> _setterExpression;
        private readonly int _received;

        public PropertySetUnitTest(Action<TContext> setterExpression, int received)
        {
            _setterExpression = setterExpression;
            _received = received;
        }

        public override void Run(Func<TContextMock> targetFactory)
        {
            // Arrange
            var target = targetFactory.Invoke();

            // Assert
            target.Mock.VerifySet(_setterExpression);
        }
    }
}
