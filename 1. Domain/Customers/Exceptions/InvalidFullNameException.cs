using CommerX.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerX.Domain.Customers.Exceptions
{
    // sealed: excepción final, no puede heredarse
    public sealed class InvalidFullNameException : DomainException
    {
        // Recibe el valor inválido para incluirlo en el mensaje de error
        public InvalidFullNameException(string value)
            : base($"El nombre '{value}' no es válido. Debe tener entre 2 y 100 caracteres.") { }
    }
}
