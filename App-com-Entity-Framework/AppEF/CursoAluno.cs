﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppEF
{
    public class CursoAluno
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
