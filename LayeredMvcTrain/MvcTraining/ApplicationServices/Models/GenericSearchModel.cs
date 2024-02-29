using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Models
{
    public class GenericSearchModel<T,S> where T :new() 
    {
        public T searchModel { get; set; }
        public List<S> resultModel { get; set; }
        public GenericSearchModel()
        {
            searchModel = new T();
            resultModel = new List<S>();
        }
    }
}
