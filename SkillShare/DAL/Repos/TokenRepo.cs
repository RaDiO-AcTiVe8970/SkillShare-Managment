﻿using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, int, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Token Get(int id)
        {
            return db.Tokens.Find(id);
        }

        public List<Token> GetALL()
        {
            return db.Tokens.ToList();
        }

        public Token Update(Token obj)
        {
            throw new NotImplementedException();
        }
    }
}
