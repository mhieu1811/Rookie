﻿using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;
using System.Collections.Generic;

namespace Rookie.Ecom.UnitTests.API.Validators.TestData
{
    public static class CategoryTestData
    {
        public static IEnumerable<object[]> ValidTexts()
        {
            return new object[][]
            {
                new object[] { "category name" },
                new object[] { "category" },
            };
        }

        public static IEnumerable<object[]> InvalidNames()
        {
            return new object[][]
            {
                new object[]
                {
                    "Mattis adipiscing magnis montes semper. Amet risus venenatis. " +
                    "Suspendisse pede pharetra nec praesent cursus nibh tortor pharetra ante commodo et."+
                    "Suspendisse pede pharetra nec praesent cursus nibh tortor pharetra ante commodo et.",
                    string.Format(ErrorTypes.Common.MaxLengthError, ValidationRules.CategoryRules.MaxLenghCharactersForName)
                },
                new object[] { null, string.Format(ErrorTypes.Common.RequiredError, nameof(CategoryDto.CategoryName))},
            };
        }

        public static IEnumerable<object[]> InvalidDescs()
        {
            return new object[][]
            {
                new object[]
                {
                    "Mattis adipiscing magnis montes semper. Amet risus venenatis." +
                    "Mattis adipiscing magnis montes semper. Amet risus venenatis." +
                    "Mattis adipiscing magnis montes semper. Amet risus venenatis." +
                    "Mattis adipiscing magnis montes semper. Amet risus venenatis." +
                    "Mattis adipiscing magnis montes semper. Amet risus venenatis." +
                    "Mattis adipiscing magnis montes semper. Amet risus venenatis. " ,
                    string.Format(ErrorTypes.Common.MaxLengthError, ValidationRules.CategoryRules.MaxLenghCharactersForDesc)
                }
            };
        }
    }
}
