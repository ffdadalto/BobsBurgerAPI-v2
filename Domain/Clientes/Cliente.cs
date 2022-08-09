﻿using BobsBurgerAPI_v2.Domain.Enderecos;

namespace BobsBurgerAPI_v2.Domain.Clientes;

public class Cliente : Entity
{
    public string? Apelido { get; set; }
    public string Telefone { get; set; }
    public string? Cep { get; set; }
    public string Endereco { get; set; }
    public string Numero { get; set; }
    public int BairroId { get; set; }
    public Bairro Bairro { get; set; }

    public Cliente(string nome, string apelido, string telefone, string cep, string endereco,
        string numero, int bairroId, bool ativo)
    {
        Nome = nome;
        Apelido = apelido;
        Telefone = telefone;
        Cep = cep;
        Endereco = endereco;
        Numero = numero;
        BairroId = bairroId;
        Ativo = ativo;
        CriadoPor = "Dev";
        CriadodEm = DateTime.Now;
    }

    public void EditInfo(string nome, string apelido, string telefone, string cep, string endereco,
        string numero, int bairroId, bool ativo)
    {
        Nome = nome;
        Apelido = apelido;
        Telefone = telefone;
        Cep = cep;
        Endereco = endereco;
        Numero = numero;
        BairroId = bairroId;
        Ativo = ativo;
        EditadoPor = "Dev";
        EditadoEm = DateTime.Now;
    }
}