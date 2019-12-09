﻿using Adapter.Core;
using System.Collections.Generic;
using Xunit;

namespace Tests.Feature
{
    public class RazorHtmlTest
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { new { Id = 1 }, "<div id=\"app\" data-page={\"id\":1}></div>" };
            yield return new object[] { new { Id = "Andy" }, "<div id=\"app\" data-page={\"id\":\"Andy\"}></div>" };
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void ItGeneratesRazorHtmlContent(dynamic model, string excepted)
        {
            var actual = new ResultFactory().Html(model).ToString();

            Assert.Equal(excepted, actual);
        }
    }
}