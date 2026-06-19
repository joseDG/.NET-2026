using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class LibroTituloComparer : IEqualityComparer<Libro>
    {
        private IEqualityComparer<string> TituloComparer { get; } = StringComparer.OrdinalIgnoreCase;
        public bool Equals(Libro? x, Libro? y) =>
            StringComparer.OrdinalIgnoreCase.Equals(x!.Titulo, y!.Titulo);
        

        public int GetHashCode([DisallowNull] Libro obj) =>
            StringComparer.OrdinalIgnoreCase.GetHashCode(obj!.Titulo!);
       
    }
}
