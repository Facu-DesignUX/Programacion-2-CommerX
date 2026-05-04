using System;
using CommerX.Domain.Customers.ValueObjects;
using CommerX.Domain.Customers.Exceptions;
using CommerX.Domain.Common.Exceptions;

Console.WriteLine("--- INICIANDO PRUEBAS DEL DOMINIO ---\n");

// PRUEBA 1: Fail Fast en Email (Módulo 3B)
/*try
{
    Console.WriteLine("1. Probando crear un Email inválido...");
    var emailInvalido = EmailAddress.Create("noesvalido");
}
catch (InvalidEmailException ex)
{
    // Debería imprimir: "El email 'noesvalido' no tiene formato válido..."
    Console.WriteLine($"[ÉXITO] Excepción capturada: {ex.Message}\n");
}*/

// PRUEBA 2: Fail Fast en Edad (Módulo 3B)
/*
try
{
    Console.WriteLine("2. Probando crear un cliente menor de edad...");
    var fechaMenor = DateOnly.FromDateTime(DateTime.Today.AddYears(-10));
    var birthDate = BirthDate.Create(fechaMenor);
}
catch (InvalidAgeException ex)
{
    // Debería imprimir que no cumple el requisito de 18 años
    Console.WriteLine($"[ÉXITO] Excepción capturada: {ex.Message}\n");
}*/

// PRUEBA 3: Igualdad por valor y normalización (Módulo 2C)
Console.WriteLine("3. Probando normalización e igualdad en Document...");
var doc1 = Document.Create("abc1234");
var doc2 = Document.Create("ABC1234");

Console.WriteLine($"doc1: {doc1.Value}"); // Debe imprimir ABC1234
Console.WriteLine($"doc2: {doc2.Value}"); // Debe imprimir ABC1234

if (doc1 == doc2)
{
    Console.WriteLine("[ÉXITO] Los documentos son iguales por valor aunque se ingresaron distinto.\n");
}
