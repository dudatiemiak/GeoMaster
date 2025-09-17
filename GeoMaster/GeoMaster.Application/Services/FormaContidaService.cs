using System;
using GeoMaster.Domain.Entities;
using GeoMaster.GeoMaster.Application.Interfaces;

namespace GeoMaster.GeoMaster.Application.Services
{
    public class FormaContidaService : IFormaContidaService
    {
        private const double limiteVirgula = 1e-9;

        public bool VerificarContencao(object formaInterna, object formaExterna)
        {
            // Se ambas as formas são círculos, verifica se o raio do círculo interno é menor ou igual ao do externo
            if (formaInterna is Circulo ci && formaExterna is Circulo ce)
                return ci.Raio <= ce.Raio + limiteVirgula;
            // Se a forma interna é um círculo e a externa é um retângulo, verifica se o diâmetro do círculo cabe dentro das dimensões do retângulo
            if (formaInterna is Circulo c && formaExterna is Retangulo rect)
                return 2 * c.Raio <= rect.Largura + limiteVirgula && 2 * c.Raio <= rect.Altura + limiteVirgula;
            // Se a forma interna é um retângulo e a externa é um círculo, verifica se a diagonal do retângulo cabe dentro do diâmetro do círculo
            if (formaInterna is Retangulo r && formaExterna is Circulo circ)
            {
                double metadeDiagonal = Math.Sqrt(Math.Pow(r.Largura / 2.0, 2) + Math.Pow(r.Altura / 2.0, 2));
                return metadeDiagonal <= circ.Raio + limiteVirgula;
            }
            // Se ambas as formas são retângulos, basta verificar se a altura e a largura são menores ou iguais às do retângulo externo
            if (formaInterna is Retangulo ri && formaExterna is Retangulo re)
                return ri.Largura <= re.Largura + limiteVirgula && ri.Altura <= re.Altura + limiteVirgula;

            return false;
        }
    }
}
