using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Recruitment.Models;
using System.Data;
using System.Data.Entity;


namespace Recruitment.Helpers
{
    public class Shared
    {
        public static RecruitmentEntities db = new RecruitmentEntities();

        public static  IEnumerable<RepositoryOfAnswer> Answers (int? Answer_id) 
        {
            return db.RepositoryOfAnswers.Where(c => c.Answers_id == Answer_id).ToList();
        }
    }

}
   