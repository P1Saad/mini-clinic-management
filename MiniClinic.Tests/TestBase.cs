using Application.Common.Mapping;
using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniClinic.Tests
{
    public abstract class TestBase
    {
        protected static IMapper Mapper => new MapperConfiguration(c => c.AddProfile<MappingConfig>()).CreateMapper();
        protected static IList<ValidationResult> Validate(object value)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(value, new ValidationContext(value), results, true);
            return results;
        }
        protected static NullLogger<T> Logger<T>() => NullLogger<T>.Instance;
    }
}
