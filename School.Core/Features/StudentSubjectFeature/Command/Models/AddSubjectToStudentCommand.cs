﻿using MediatR;
using School.Core.Bases;

namespace School.Core.Features.StudentSubjectFeature.Command.Models
{
    public class AddSubjectToStudentCommand : IRequest<Response<string>>
    {
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public double? grade { get; set; }
    }
}
