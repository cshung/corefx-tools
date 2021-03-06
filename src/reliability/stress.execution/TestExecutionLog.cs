﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// 

using System;
using System.Threading;

namespace stress.execution
{
    public class TestExecutionLog
    {
        private long _execTime = 0;
        private int _failedCount = 0;
        private int _passedCount = 0;
        private int _currentCount = 0;

        public long ExecTime { get { return _execTime; } }

        public int FailedCount { get { return _failedCount; } }
        public int PassedCount { get { return _passedCount; } }

        public long BeginTest()
        {
            Interlocked.Increment(ref _currentCount);

            return DateTime.Now.Ticks;
        }

        public void EndTest(long begin, bool pass)
        {
            Interlocked.Add(ref _execTime, DateTime.Now.Ticks - begin);

            Interlocked.Decrement(ref _currentCount);

            if (pass)
            {
                Interlocked.Increment(ref _passedCount);
            }
            else
            {
                Interlocked.Increment(ref _failedCount);
            }
        }
    }
}