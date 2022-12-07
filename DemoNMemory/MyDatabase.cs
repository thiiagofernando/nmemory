using DemoNMemory.Entidade;
using NMemory;
using NMemory.Indexes;
using NMemory.Modularity;
using NMemory.Tables;

namespace DemoNMemory
{
    public class MyDatabase : Database
    {
        public MyDatabase()
        {
            CreateCidadeEstado();
            PopularDados();
        }
        private void PopularDados()
        {
            
            this.Estados.Insert(new Estado() { Id = 1, NomeEstado = "Estado_1" });

            this.Cidades.Insert(new Cidade() { Id = 1, Nome = "Cidade_1", EstadoId = 1 });

            this.Estados.Insert(new Estado() { Id = 2, NomeEstado = "Estado_2" });

            this.Cidades.Insert(new Cidade() { Id = 2, Nome = "Cidade_2", EstadoId = 2 });
        }

        private void CreateCidadeEstado()
        {
            var estado = base.Tables.Create<Estado, int>(g => g.Id);
            var cidade = this.Tables.Create<Cidade, int>(x => x.Id);

            this.Estados = estado;
            this.Cidades = cidade;

            RelationOptions options = new RelationOptions(
                cascadedDeletion: true);

            var peopleGroupIdIndex = cidade.CreateIndex(
                new RedBlackTreeIndexFactory(),
                p => p.EstadoId);

            this.Tables.CreateRelation(
                estado.PrimaryKeyIndex,
                peopleGroupIdIndex,
                x => x,
                x => x,
                options);
        }

        public ITable<Cidade> Cidades { get; private set; }
        public ITable<Estado> Estados { get; private set; }
    }
}
