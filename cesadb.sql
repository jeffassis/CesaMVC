-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/

--
-- Banco de dados: `cesadb`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_aluno`
--

CREATE TABLE `tb_aluno` (
  `id_aluno` int(11) NOT NULL,
  `nome` varchar(80) NOT NULL,
  `rg` varchar(20) NOT NULL,
  `cpf` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `nascimento` date NOT NULL,
  `telefone` varchar(20) NOT NULL,
  `celular` varchar(20) NOT NULL,
  `sangue` varchar(20) NOT NULL,
  `endereco` varchar(150) NOT NULL,
  `cep` varchar(20) NOT NULL,
  `bairro` varchar(30) NOT NULL,
  `cidade` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `imagem` longblob
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_aluno_turma`
--

CREATE TABLE `tb_aluno_turma` (
  `id_aluno_turma` int(11) NOT NULL,
  `aluno_id` int(11) NOT NULL,
  `turma_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_ano`
--

CREATE TABLE `tb_ano` (
  `id_ano` int(11) NOT NULL,
  `ano` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tb_ano`
--

INSERT INTO `tb_ano` (`id_ano`, `ano`) VALUES
(1, '2023');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_bimestre`
--

CREATE TABLE `tb_bimestre` (
  `id_bimestre` int(11) NOT NULL,
  `bimestre` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tb_bimestre`
--

INSERT INTO `tb_bimestre` (`id_bimestre`, `bimestre`) VALUES
(1, 'Primeiro'),
(2, 'Segundo'),
(3, 'Terceiro'),
(4, 'Quarto');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_dia_semana`
--

CREATE TABLE `tb_dia_semana` (
  `id_dia` int(11) NOT NULL,
  `dia` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tb_dia_semana`
--

INSERT INTO `tb_dia_semana` (`id_dia`, `dia`) VALUES
(1, 'Segunda'),
(2, 'Terça'),
(3, 'Quarta'),
(4, 'Quinta'),
(5, 'Sexta');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_disciplina`
--

CREATE TABLE `tb_disciplina` (
  `id_disciplina` int(11) NOT NULL,
  `nome` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tb_disciplina`
--

INSERT INTO `tb_disciplina` (`id_disciplina`, `nome`) VALUES
(1, 'Português'),
(2, 'Matemática'),
(3, 'História'),
(4, 'Geografia'),
(5, 'Biologia'),
(6, 'Inglês'),
(7, 'Ciências'),
(8, 'Ed. Fisica'),
(9, 'Artes'),
(10, 'Intervalo');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_fornecedor`
--

CREATE TABLE `tb_fornecedor` (
  `id_fornecedor` int(11) NOT NULL,
  `nome` varchar(150) NOT NULL,
  `endereco` varchar(150) NOT NULL,
  `telefone` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_gasto`
--

CREATE TABLE `tb_gasto` (
  `id_gasto` int(11) NOT NULL,
  `descricao` varchar(100) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `funcionario` varchar(100) NOT NULL,
  `data` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_horario`
--

CREATE TABLE `tb_horario` (
  `id_horario` int(11) NOT NULL,
  `descricao` varchar(30) NOT NULL,
  `dia_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tb_horario`
--

INSERT INTO `tb_horario` (`id_horario`, `descricao`, `dia_id`) VALUES
(1, '07:00 - 07:50', 1),
(2, '07:50 - 08:40', 1),
(3, '08:40 - 09:30', 1),
(4, '09:30 - 09:45', 1),
(5, '09:45 - 10:30', 1),
(6, '10:30 - 11:20', 1),
(7, '11:20 - 12:10', 1),
(8, '07:00 - 07:50', 2),
(9, '07:00 - 08:40', 2),
(10, '08:40 - 09:30', 2),
(12, '09:30 - 09:45', 2),
(13, '09:45 - 10:30', 2),
(14, '10:30 - 11:20', 2),
(15, '11:20 - 12:10', 2),
(16, '07:00 - 07:50', 3),
(17, '07:50 - 08:40', 3),
(18, '08:40 - 09:30', 3),
(19, '09:30 - 09:45', 3),
(20, '09:45 - 10:30', 3),
(21, '10:30 - 11:20', 3),
(22, '11:20 - 12:10', 3),
(23, '07:00 - 07:50', 4),
(24, '07:50 - 08:40', 4),
(25, '08:40 - 09:30', 4),
(26, '09:30 - 09:45', 4),
(27, '09:45 - 10:30', 4),
(28, '10:30 - 11:20', 4),
(29, '11:20 - 12:10', 4),
(30, '07:00 - 07:50', 5),
(31, '07:50 - 08:40', 5),
(32, '08:40 - 09:30', 5),
(33, '09:30 - 09:45', 5),
(34, '09:45 - 10:30', 5),
(35, '10:30 - 11:20', 5),
(36, '11:20 - 12:10', 5);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_hora_professor`
--

CREATE TABLE `tb_hora_professor` (
  `id_hora_professor` int(11) NOT NULL,
  `horario_id` int(11) NOT NULL,
  `disciplina_id` int(11) NOT NULL,
  `turma_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_itemvenda`
--

CREATE TABLE `tb_itemvenda` (
  `id_item` int(11) NOT NULL,
  `venda_id` int(11) NOT NULL,
  `produto_id` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_mensalidade`
--

CREATE TABLE `tb_mensalidade` (
  `id_mensalidade` int(11) NOT NULL,
  `turma_id` int(11) NOT NULL,
  `aluno_id` int(11) NOT NULL,
  `servico_id` int(11) NOT NULL,
  `data` date NOT NULL,
  `funcionario` varchar(100) NOT NULL,
  `situacao` varchar(20) NOT NULL DEFAULT 'Pendete',
  `mes` varchar(20) NOT NULL,
  `observacao` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_movimentacao`
--

CREATE TABLE `tb_movimentacao` (
  `id_movimentacao` int(11) NOT NULL,
  `tipo` varchar(20) NOT NULL,
  `movimento` varchar(30) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `funcionario` varchar(100) NOT NULL,
  `data` date NOT NULL,
  `id_movimento` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_nota`
--

CREATE TABLE `tb_nota` (
  `id_nota` int(11) NOT NULL,
  `aluno_id` int(11) NOT NULL,
  `disciplina_id` int(11) NOT NULL,
  `turma_id` int(11) NOT NULL,
  `bimestre_id` int(11) NOT NULL,
  `tipo` varchar(20) NOT NULL,
  `nota` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_produto`
--

CREATE TABLE `tb_produto` (
  `id_produto` int(11) NOT NULL,
  `nome` varchar(50) NOT NULL,
  `descricao` varchar(150) NOT NULL,
  `estoque` int(11) NOT NULL,
  `fornecedor_id` int(11) NOT NULL,
  `valor_venda` decimal(10,2) NOT NULL,
  `valor_compra` decimal(10,2) NOT NULL,
  `data` date NOT NULL,
  `imagem` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_professor`
--

CREATE TABLE `tb_professor` (
  `id_professor` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `rg` varchar(20) NOT NULL,
  `cpf` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `nascimento` date NOT NULL,
  `telefone` varchar(20) NOT NULL,
  `celular` varchar(20) NOT NULL,
  `sangue` varchar(20) NOT NULL,
  `endereco` varchar(150) NOT NULL,
  `cep` varchar(20) NOT NULL,
  `bairro` varchar(30) NOT NULL,
  `cidade` varchar(30) NOT NULL,
  `estado` varchar(2) NOT NULL,
  `imagem` longblob
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_responsavel`
--

CREATE TABLE `tb_responsavel` (
  `id_responsavel` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `rg` varchar(20) NOT NULL,
  `cpf` varchar(20) NOT NULL,
  `parentesco` varchar(20) NOT NULL,
  `telefone` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_servico`
--

CREATE TABLE `tb_servico` (
  `id_servico` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `valor` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_turma`
--

CREATE TABLE `tb_turma` (
  `id_turma` int(11) NOT NULL,
  `nome` varchar(30) NOT NULL,
  `serie` varchar(20) NOT NULL,
  `turno` varchar(20) NOT NULL,
  `ano_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tb_turma`
--

INSERT INTO `tb_turma` (`id_turma`, `nome`, `serie`, `turno`, `ano_id`) VALUES
(1, '101 - 2023', '1º ANO', 'TARDE', 1),
(2, '201 - 2023', '2º ANO', 'TARDE', 1),
(3, '301 - 2023', '3º ANO', 'TARDE', 1),
(4, '601 - 2023', '6º ANO', 'MANHÃ', 1),
(5, '501 - 2023', '5º ANO', 'MANHÃ', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_user`
--

CREATE TABLE `tb_user` (
  `id_user` int(11) NOT NULL,
  `nome` varchar(80) NOT NULL,
  `username` varchar(30) NOT NULL,
  `senha` varchar(20) NOT NULL,
  `status` varchar(20) NOT NULL,
  `nivel` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tb_user`
--

INSERT INTO `tb_user` (`id_user`, `nome`, `username`, `senha`, `status`, `nivel`) VALUES
(1, 'Administrador', 'admin', 'jean1420', 'Ativo', 3),
(2, 'Rodrigo Souza', 'rodrigo', '123', 'Ativo', 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tb_venda`
--

CREATE TABLE `tb_venda` (
  `id_venda` int(11) NOT NULL,
  `funcionario` varchar(80) NOT NULL,
  `data_venda` date NOT NULL,
  `total_venda` double NOT NULL,
  `obs` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `tb_aluno`
--
ALTER TABLE `tb_aluno`
  ADD PRIMARY KEY (`id_aluno`);

--
-- Índices para tabela `tb_aluno_turma`
--
ALTER TABLE `tb_aluno_turma`
  ADD PRIMARY KEY (`id_aluno_turma`);

--
-- Índices para tabela `tb_ano`
--
ALTER TABLE `tb_ano`
  ADD PRIMARY KEY (`id_ano`);

--
-- Índices para tabela `tb_bimestre`
--
ALTER TABLE `tb_bimestre`
  ADD PRIMARY KEY (`id_bimestre`);

--
-- Índices para tabela `tb_dia_semana`
--
ALTER TABLE `tb_dia_semana`
  ADD PRIMARY KEY (`id_dia`);

--
-- Índices para tabela `tb_disciplina`
--
ALTER TABLE `tb_disciplina`
  ADD PRIMARY KEY (`id_disciplina`);

--
-- Índices para tabela `tb_fornecedor`
--
ALTER TABLE `tb_fornecedor`
  ADD PRIMARY KEY (`id_fornecedor`);

--
-- Índices para tabela `tb_gasto`
--
ALTER TABLE `tb_gasto`
  ADD PRIMARY KEY (`id_gasto`);

--
-- Índices para tabela `tb_horario`
--
ALTER TABLE `tb_horario`
  ADD PRIMARY KEY (`id_horario`);

--
-- Índices para tabela `tb_hora_professor`
--
ALTER TABLE `tb_hora_professor`
  ADD PRIMARY KEY (`id_hora_professor`);

--
-- Índices para tabela `tb_itemvenda`
--
ALTER TABLE `tb_itemvenda`
  ADD PRIMARY KEY (`id_item`);

--
-- Índices para tabela `tb_mensalidade`
--
ALTER TABLE `tb_mensalidade`
  ADD PRIMARY KEY (`id_mensalidade`);

--
-- Índices para tabela `tb_movimentacao`
--
ALTER TABLE `tb_movimentacao`
  ADD PRIMARY KEY (`id_movimentacao`);

--
-- Índices para tabela `tb_nota`
--
ALTER TABLE `tb_nota`
  ADD PRIMARY KEY (`id_nota`),
  ADD KEY `aluno_id` (`aluno_id`),
  ADD KEY `bimestre_id` (`bimestre_id`),
  ADD KEY `disciplina_id` (`disciplina_id`),
  ADD KEY `turma_id` (`turma_id`);

--
-- Índices para tabela `tb_produto`
--
ALTER TABLE `tb_produto`
  ADD PRIMARY KEY (`id_produto`);

--
-- Índices para tabela `tb_professor`
--
ALTER TABLE `tb_professor`
  ADD PRIMARY KEY (`id_professor`);

--
-- Índices para tabela `tb_responsavel`
--
ALTER TABLE `tb_responsavel`
  ADD PRIMARY KEY (`id_responsavel`);

--
-- Índices para tabela `tb_servico`
--
ALTER TABLE `tb_servico`
  ADD PRIMARY KEY (`id_servico`);

--
-- Índices para tabela `tb_turma`
--
ALTER TABLE `tb_turma`
  ADD PRIMARY KEY (`id_turma`);

--
-- Índices para tabela `tb_user`
--
ALTER TABLE `tb_user`
  ADD PRIMARY KEY (`id_user`);

--
-- Índices para tabela `tb_venda`
--
ALTER TABLE `tb_venda`
  ADD PRIMARY KEY (`id_venda`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `tb_aluno`
--
ALTER TABLE `tb_aluno`
  MODIFY `id_aluno` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1;

--
-- AUTO_INCREMENT de tabela `tb_aluno_turma`
--
ALTER TABLE `tb_aluno_turma`
  MODIFY `id_aluno_turma` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1;

--
-- AUTO_INCREMENT de tabela `tb_ano`
--
ALTER TABLE `tb_ano`
  MODIFY `id_ano` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `tb_bimestre`
--
ALTER TABLE `tb_bimestre`
  MODIFY `id_bimestre` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de tabela `tb_dia_semana`
--
ALTER TABLE `tb_dia_semana`
  MODIFY `id_dia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `tb_disciplina`
--
ALTER TABLE `tb_disciplina`
  MODIFY `id_disciplina` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de tabela `tb_fornecedor`
--
ALTER TABLE `tb_fornecedor`
  MODIFY `id_fornecedor` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tb_gasto`
--
ALTER TABLE `tb_gasto`
  MODIFY `id_gasto` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tb_horario`
--
ALTER TABLE `tb_horario`
  MODIFY `id_horario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT de tabela `tb_hora_professor`
--
ALTER TABLE `tb_hora_professor`
  MODIFY `id_hora_professor` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tb_itemvenda`
--
ALTER TABLE `tb_itemvenda`
  MODIFY `id_item` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tb_mensalidade`
--
ALTER TABLE `tb_mensalidade`
  MODIFY `id_mensalidade` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tb_movimentacao`
--
ALTER TABLE `tb_movimentacao`
  MODIFY `id_movimentacao` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tb_nota`
--
ALTER TABLE `tb_nota`
  MODIFY `id_nota` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tb_produto`
--
ALTER TABLE `tb_produto`
  MODIFY `id_produto` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tb_professor`
--
ALTER TABLE `tb_professor`
  MODIFY `id_professor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `tb_responsavel`
--
ALTER TABLE `tb_responsavel`
  MODIFY `id_responsavel` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tb_servico`
--
ALTER TABLE `tb_servico`
  MODIFY `id_servico` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tb_turma`
--
ALTER TABLE `tb_turma`
  MODIFY `id_turma` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `tb_user`
--
ALTER TABLE `tb_user`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `tb_venda`
--
ALTER TABLE `tb_venda`
  MODIFY `id_venda` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `tb_nota`
--
ALTER TABLE `tb_nota`
  ADD CONSTRAINT `tb_nota_ibfk_1` FOREIGN KEY (`aluno_id`) REFERENCES `tb_aluno` (`id_aluno`),
  ADD CONSTRAINT `tb_nota_ibfk_2` FOREIGN KEY (`bimestre_id`) REFERENCES `tb_bimestre` (`id_bimestre`),
  ADD CONSTRAINT `tb_nota_ibfk_3` FOREIGN KEY (`disciplina_id`) REFERENCES `tb_disciplina` (`id_disciplina`),
  ADD CONSTRAINT `tb_nota_ibfk_4` FOREIGN KEY (`turma_id`) REFERENCES `tb_turma` (`id_turma`);
COMMIT;
