using System;

namespace PReflection
{
	public abstract class ValidationAttribute : Attribute
	{
		public string Validate(object obj);
	}
}

