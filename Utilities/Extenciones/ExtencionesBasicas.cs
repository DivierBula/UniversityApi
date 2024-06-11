using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilidades.Extenciones
{
    public static class ExtencionesBasicas
    {
        public static bool IsNull(this object objeto)
        {
            return objeto == null || objeto is DBNull;
        }

        public static bool IsCero(this int numero)
        {
            return numero == 0;
        }

        public static bool IsNotNull(this object objeto)
        {
            return !objeto.IsNull();
        }

        public static bool IsValid(this DateTime fecha)
        {
            return !fecha.IsNull() && fecha > DateTime.MinValue && fecha < DateTime.MaxValue;
        }

        public static bool IsNullOrEmpty(this string cadena)
        {
            return string.IsNullOrEmpty(cadena);
        }

        public static bool IsValidaDate(this string date)
        {
            DateTime result;
            return DateTime.TryParse(date, out result);
        }

        public static bool IsNullOrEmpty(this Guid guid)
        {
            return guid.IsNull() || guid == Guid.Empty;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> lista)
        {
            return lista.IsNull() || !lista.Any<T>();
        }
    }
}
