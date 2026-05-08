# Sistema Bancário - Conta Bancária

Projeto desenvolvido em **C#** com conceitos de **Orientação a Objetos**, como herança, abstração, polimorfismo e interfaces.

---

## Funcionalidades

- Criar conta (Corrente ou Poupança)
- Listar todas as contas
- Buscar conta por número
- Atualizar dados da conta
- Apagar conta
- Sacar (com validação de saldo e limite de crédito)
- Depositar
- Transferir entre contas

---

## Estrutura do Projeto

```
ContaBancaria/
├── Menu.cs                        # Classe principal com menu interativo
├── Model/
│   ├── Conta.cs                   # Classe abstrata base
│   ├── ContaCorrente.cs           # Herda de Conta — possui limite de crédito
│   └── ContaPoupanca.cs           # Herda de Conta — possui dia de aniversário
├── Repository/
│   └── ContaRepository.cs         # Interface com os métodos do sistema
├── Controller/
│   └── ContaController.cs         # Implementa ContaRepository
└── Util/
    └── Cores.cs                   # Utilitário de cores para o terminal
```

---

## Diagrama de Classes

```
          ┌──────────────────┐
          │    <<interface>> │
          │ ContaRepository  │
          └────────┬─────────┘
                   │ implementa
          ┌────────▼─────────┐
          │ ContaController  │
          └──────────────────┘

          ┌──────────────────┐
          │    Conta (abs)   │
          └────────┬─────────┘
         ┌─────────┴──────────┐
┌────────▼───────┐   ┌────────▼──────────┐
│ ContaCorrente  │   │   ContaPoupanca   │
└────────────────┘   └───────────────────┘
```

---

## Como Executar

### Pre-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download) instalado

### Passos

```bash
# Clone o repositório
git clone https://github.com/SEU_USUARIO/ContaBancaria.git

# Entre na pasta do projeto
cd ContaBancaria

# Execute o projeto
dotnet run
```

---

## Conceitos Aplicados

| Conceito | Onde foi usado |
|---|---|
| **Abstração** | Classe `Conta` é abstrata |
| **Herança** | `ContaCorrente` e `ContaPoupanca` herdam de `Conta` |
| **Polimorfismo** | Método `Sacar()` sobrescrito em cada subclasse |
| **Interface** | `ContaRepository` define o contrato do sistema |
| **Encapsulamento** | Atributos com getters/setters controlados |

---

## Autor

Feito por **Mateus** — Projeto da Semana 1 e 2 do curso de C#.
