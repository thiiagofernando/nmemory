using System;

namespace DemoNMemory.Entidade
{
    public class Entidade
    {
        public Entidade()
        {
            CriadoEm = DateTime.Now;
            Excluido= false;
        }
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public bool Excluido { get; set; }
    }
}
