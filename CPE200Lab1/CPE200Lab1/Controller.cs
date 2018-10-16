﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
     class Controller
    {
        protected ArrayList mList;

        public Controller()
        {
            mList = new ArrayList();
        }

        public void AddModel(Model m)
        {
            mList.Add(m);
        }

        // virtual keyword allow the method to be overriden
        public virtual void Calculate(string operate, string operand)
        {
            throw new NotImplementedException();
        }

        public virtual void isNumber(string str)
        {
            throw new NotImplementedException();
        }

        public virtual void isOperator(string str)
        {
            throw new NotImplementedException();
        }
    }
}
