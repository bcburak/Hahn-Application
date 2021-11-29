using FluentValidation;
using Hahn.ApplicatonProcess.July2021.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Validator
{
	public class UserValidator : AbstractValidator<Users>
	{
		public UserValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Age)
				.NotNull()
				.WithMessage("Max. number of team members is required")
				.GreaterThan(18)
				.WithMessage("Max. number of team members must be greater than 18");
			RuleFor(x => x.LastName).MinimumLength(3);
			RuleFor(x => x.Email).EmailAddress();
		}
	}
}
