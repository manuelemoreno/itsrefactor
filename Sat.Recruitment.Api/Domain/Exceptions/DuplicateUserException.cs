using System;

namespace Sat.Recruitment.Api.Domain.Exceptions;

public class DuplicateUserException : Exception
{
    public DuplicateUserException()
        : base("Duplicate User. Please verify the info") { }
}