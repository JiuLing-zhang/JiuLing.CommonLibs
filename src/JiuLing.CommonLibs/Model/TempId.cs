using System;
using System.Collections.Generic;
using System.Text;

namespace JiuLing.CommonLibs.Model
{
    internal class TempId
    {
        public int Id { get; set; }
        public DateTime Expiration { get; set; }
        public TempId(int id, DateTime expiration)
        {
            Id = id;
            Expiration = expiration;
        }
    }
}
