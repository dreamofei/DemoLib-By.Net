using System;
using System.Collections.Generic;
using System.Text;

namespace ElandBJ.Token.Model
{
    [Serializable]
    public class KeysDto
    {
        public string PrivateKey { get; set; }
        public string PublichKey { get; set; }
    }
}
