using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using FVTest.FluentValidation;
using FVTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FVTest.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void PutMyObject_ShouldReturnInvalidModelStateWithRenamedSubObjectProperty()
        {
            var validator = new MyObjectValidator();
            var _MyObject = new MyObject { Name = "Test1" };
            var _SubObject = new SubObject {Name = "Test"};
            var _EmptyNameSubObject = new SubObject {Name = ""};
            
            _MyObject.SubObjects = new List<SubObject> {_SubObject, _EmptyNameSubObject};

            var result = validator.Validate(_MyObject);
            foreach (var error in result.Errors)
            {
                Debug.WriteLine(error.PropertyName);
            }

            Assert.IsTrue(result.Errors.Any(o => o.PropertyName == "testing123[1].SubObject_Name"));
        }

    }
}
