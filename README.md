# CadCliente
CadCliente é uma aplicação de cadastro de clientes feita no Windows Form em C# usando o banco de dados MySql, no qual é feito operações de CRUD. Foi feito uma tela (FORM) para fazer os cadastros dos clientes, no qual contém: - Código (Auto Increment (identity) não podendo ser nulo; - Nome; - CPF (com validação de CPF); - CEP (com mascara XXXXX-XXX); - Endereço; - Número; - Complemento; - Telefone (caso seja digitado 11 números mascara: (00)0 0000-0000 e caso seja digitado 10 números mascara: (00) 0000-0000. Possui também os botões (Gravar, Editar, Excluir, Consultar e Exibir) onde realiza as operações de CRUD com os dados dos cadastros dos clientes. Ao clicar em Gravar as informações são gravadas em uma tabela e os campos da tela são desabilitados. Ao clicar em Editar habilita os campos da tela no qual o usuário insere o código do cliente a ser editado. Para excluir um cliente é só informar o código do cliente e clicar em Excluir. Para visualizar os dados de um cliente específico é só informar o código do cliente e clicar em Consultar, então os dados serão apresentados na tela. Já para visualizar os dados de todos os clientes é só clicar no botão Exibir.   

![cadCliente](https://user-images.githubusercontent.com/70042571/149240069-b9e2b54e-5548-4eae-9aad-526c3f44473c.PNG)

