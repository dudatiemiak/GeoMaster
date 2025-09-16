using System;
using GeoMaster.Application.Interfaces;
using GeoMaster.Domain.Entities;
using GeoMaster.GeoMaster.Application.Interfaces;

namespace GeoMaster.GeoMaster.Application.Services
{
    public class FormaContidaService : IFormaContidaService
    {
        private const double EPS = 1e-9;

        public bool VerificarContencao(object formaInterna, object formaExterna)
        {
            if (formaInterna is Circulo ci && formaExterna is Circulo ce)
                return ci.Raio <= ce.Raio + EPS;

            if (formaInterna is Circulo c && formaExterna is Retangulo rect)
                return 2 * c.Raio <= rect.Largura + EPS && 2 * c.Raio <= rect.Altura + EPS;

            if (formaInterna is Retangulo r && formaExterna is Circulo circ)
            {
                double halfDiagonal = Math.Sqrt(Math.Pow(r.Largura / 2.0, 2) + Math.Pow(r.Altura / 2.0, 2));
                return halfDiagonal <= circ.Raio + EPS;
            }

            if (formaInterna is Retangulo ri && formaExterna is Retangulo re)
                return ri.Largura <= re.Largura + EPS && ri.Altura <= re.Altura + EPS;

            return false;
        }
    }
}
