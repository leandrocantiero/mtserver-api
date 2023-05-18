CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `agendavisita` (
    `codigo` int NOT NULL AUTO_INCREMENT,
    `data_notificacao` date NOT NULL,
    `data_visita` date NOT NULL,
    `excluido` int NOT NULL,
    `fk_cliente_cnpj_cpf` int NOT NULL,
    `fk_vendedor` int NOT NULL,
    `horario` time(6) NOT NULL,
    `observacoes` longtext CHARACTER SET utf8mb4 NOT NULL,
    `periodo_visita` longtext CHARACTER SET utf8mb4 NOT NULL,
    `sequencia` int NOT NULL,
    CONSTRAINT `PK_agendavisita` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `autorizacaopedido` (
    `nr_pedido_palm` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `fk_vendedor` int NOT NULL,
    `data_requisicao` date NOT NULL,
    `situacao` int NOT NULL,
    `observacao` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_autorizacaopedido` PRIMARY KEY (`nr_pedido_palm`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `cidade` (
    `codigo` int NOT NULL AUTO_INCREMENT,
    `nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `uf` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_cidade` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `cliente` (
    `codigo` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `cnpj_cpf` longtext CHARACTER SET utf8mb4 NULL,
    `razao_social` longtext CHARACTER SET utf8mb4 NULL,
    `nome_fantasia` longtext CHARACTER SET utf8mb4 NULL,
    `inscr_estadual` longtext CHARACTER SET utf8mb4 NULL,
    `inscr_municipal` longtext CHARACTER SET utf8mb4 NULL,
    `categoria` longtext CHARACTER SET utf8mb4 NULL,
    `Contribuinte` longtext CHARACTER SET utf8mb4 NULL,
    `email` longtext CHARACTER SET utf8mb4 NULL,
    `fone_1` longtext CHARACTER SET utf8mb4 NULL,
    `fone_2` longtext CHARACTER SET utf8mb4 NULL,
    `fone_3` longtext CHARACTER SET utf8mb4 NULL,
    `referencia` longtext CHARACTER SET utf8mb4 NULL,
    `rota_entrega` longtext CHARACTER SET utf8mb4 NULL,
    `seq_rota_entrega` int NULL,
    `suframa` longtext CHARACTER SET utf8mb4 NULL,
    `cidade` longtext CHARACTER SET utf8mb4 NULL,
    `endereco` longtext CHARACTER SET utf8mb4 NULL,
    `bairro` longtext CHARACTER SET utf8mb4 NULL,
    `complemento` longtext CHARACTER SET utf8mb4 NULL,
    `cep` int NULL,
    `numero` int NULL,
    `uf` longtext CHARACTER SET utf8mb4 NULL,
    `endereco_cobranca` longtext CHARACTER SET utf8mb4 NULL,
    `bairro_cobranca` longtext CHARACTER SET utf8mb4 NULL,
    `complemento_cobranca` longtext CHARACTER SET utf8mb4 NULL,
    `ceo_cobranca` int NULL,
    `numero_cobranca` int NULL,
    `endereco_faturamento` longtext CHARACTER SET utf8mb4 NULL,
    `bairro_faturamento` longtext CHARACTER SET utf8mb4 NULL,
    `complemento_faturamento` longtext CHARACTER SET utf8mb4 NULL,
    `cep_faturamento` int NULL,
    `numero_faturamento` int NULL,
    `endereco_entrega` longtext CHARACTER SET utf8mb4 NULL,
    `bairro_entrega` longtext CHARACTER SET utf8mb4 NULL,
    `complemento_entrega` longtext CHARACTER SET utf8mb4 NULL,
    `cep_entrega` int NULL,
    `numero_entrega` int NULL,
    CONSTRAINT `PK_cliente` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `cobranca` (
    `codigo` int NOT NULL AUTO_INCREMENT,
    `data` date NOT NULL,
    `fk_cliente_cnpj_cpf` int NOT NULL,
    `fk_empresa` int NOT NULL,
    `fk_filial` int NOT NULL,
    `fk_tipo_titulo` int NOT NULL,
    `fk_titulo` int NOT NULL,
    `pgto_cheque` double NOT NULL,
    `pgto_dinheiro` double NOT NULL,
    `pgto_outras_especies` double NOT NULL,
    `pgto_ticket` double NOT NULL,
    `valor_corrigido` double NOT NULL,
    CONSTRAINT `PK_cobranca` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `condpgto` (
    `codigo` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `abreviatura` longtext CHARACTER SET utf8mb4 NOT NULL,
    `descricao` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_empresa` int NOT NULL,
    `quantidade_parcelas` int NOT NULL,
    CONSTRAINT `PK_condpgto` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `contatocliente` (
    `codigo` int NOT NULL AUTO_INCREMENT,
    `cargo` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ddd` longtext CHARACTER SET utf8mb4 NOT NULL,
    `departamento` longtext CHARACTER SET utf8mb4 NOT NULL,
    `email` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_cliente_cnpj_cpf` longtext CHARACTER SET utf8mb4 NOT NULL,
    `nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ramal` int NOT NULL,
    `sequencia` int NOT NULL,
    `telefone` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_contatocliente` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `empresa` (
    `codigo` int NOT NULL AUTO_INCREMENT,
    `nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `uf` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_empresa` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `enderecocobranca` (
    `cep` int NOT NULL AUTO_INCREMENT,
    `endereco` longtext CHARACTER SET utf8mb4 NOT NULL,
    `bairro` longtext CHARACTER SET utf8mb4 NOT NULL,
    `complemento` longtext CHARACTER SET utf8mb4 NOT NULL,
    `sequencia` int NOT NULL,
    `uf` longtext CHARACTER SET utf8mb4 NOT NULL,
    `cnpj_cobranca` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_cliente_cnpj_cpf` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_codigo_cidade` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_enderecocobranca` PRIMARY KEY (`cep`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `enderecoentrega` (
    `cep` int NOT NULL AUTO_INCREMENT,
    `endereco` longtext CHARACTER SET utf8mb4 NOT NULL,
    `bairro` longtext CHARACTER SET utf8mb4 NOT NULL,
    `complemento` longtext CHARACTER SET utf8mb4 NOT NULL,
    `sequencia` int NOT NULL,
    `uf` longtext CHARACTER SET utf8mb4 NOT NULL,
    `cnpj` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_cliente_cnpj_cpf` longtext CHARACTER SET utf8mb4 NOT NULL,
    `inscricao_estadual` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_codigo_cidade` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_enderecoentrega` PRIMARY KEY (`cep`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `estoquedisponivel` (
    `codigo_local_armazenamento` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `fk_empresa` int NOT NULL,
    `fk_filial` int NOT NULL,
    `fk_item_grade1` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_item_grade2` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_item_grade3` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_produto` longtext CHARACTER SET utf8mb4 NOT NULL,
    `quantidade` double NOT NULL,
    CONSTRAINT `PK_estoquedisponivel` PRIMARY KEY (`codigo_local_armazenamento`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `evento` (
    `codigo` int NOT NULL AUTO_INCREMENT,
    `descricao` longtext CHARACTER SET utf8mb4 NOT NULL,
    `data_hora` datetime(6) NOT NULL,
    `fk_tipo_evento` int NOT NULL,
    `fk_vendedor` longtext CHARACTER SET utf8mb4 NOT NULL,
    `visualizado` int NOT NULL,
    CONSTRAINT `PK_evento` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `familiaproduto` (
    `codigo` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `descricao` longtext CHARACTER SET utf8mb4 NULL,
    `fk_empresa` int NULL,
    CONSTRAINT `PK_familiaproduto` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `faturamentopedido` (
    `nr_pedido_palm` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `nr_pedido_retaguarda` longtext CHARACTER SET utf8mb4 NOT NULL,
    `data_faturamento` date NOT NULL,
    `fk_empresa` int NOT NULL,
    `fk_filial` int NOT NULL,
    `fk_vendedor` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_produto` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_item_grade1` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_item_grade2` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_item_grade3` longtext CHARACTER SET utf8mb4 NOT NULL,
    `numero_nf` int NOT NULL,
    `quantidade_faturada` double NOT NULL,
    `seq_item_nf` int NOT NULL,
    `serie_nf` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_faturamentopedido` PRIMARY KEY (`nr_pedido_palm`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `filial` (
    `codigo` int NOT NULL AUTO_INCREMENT,
    `nome` longtext CHARACTER SET utf8mb4 NULL,
    `uf` longtext CHARACTER SET utf8mb4 NULL,
    `fk_empresa` int NOT NULL,
    CONSTRAINT `PK_filial` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `formapgto` (
    `codigo` int NOT NULL AUTO_INCREMENT,
    `fk_empresa` int NOT NULL,
    `abreviatura` int NOT NULL,
    CONSTRAINT `PK_formapgto` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `historicocliente` (
    `nr_pedido_palm` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `limite_credito` double NOT NULL,
    `situacao_cliente` longtext CHARACTER SET utf8mb4 NOT NULL,
    `fk_cliente_cnpj_cpf` int NOT NULL,
    `fk_cond_pgto` int NOT NULL,
    `fk_empresa` int NOT NULL,
    `fk_filial` int NOT NULL,
    `fk_forma_pgto` int NOT NULL,
    `fk_oper_comercial` int NOT NULL,
    `fk_tipo_cobranca` int NOT NULL,
    `fk_transportadora` int NOT NULL,
    `fk_vendedor` int NOT NULL,
    `cod_categoria1` longtext CHARACTER SET utf8mb4 NOT NULL,
    `cod_categoria2` longtext CHARACTER SET utf8mb4 NOT NULL,
    `cod_categoria3` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_historicocliente` PRIMARY KEY (`nr_pedido_palm`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `imagem` (
    `nome` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `data` date NOT NULL,
    `hora` time(6) NOT NULL,
    `hash` longtext CHARACTER SET utf8mb4 NOT NULL,
    `is_atualizado` tinyint(1) NOT NULL,
    CONSTRAINT `PK_imagem` PRIMARY KEY (`nome`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `justificativa` (
    `codigo` int NOT NULL AUTO_INCREMENT,
    `descricao` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_justificativa` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `meta` (
    `fk_filial` int NOT NULL,
    `fk_vendedor` varchar(7) CHARACTER SET utf8mb4 NOT NULL,
    `fk_produto` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
    `fk_familia` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
    `fk_cliente_cnpj_cpf` varchar(14) CHARACTER SET utf8mb4 NOT NULL,
    `periodo` longtext CHARACTER SET utf8mb4 NOT NULL,
    `quantidade` double NOT NULL,
    `valor` double NOT NULL,
    CONSTRAINT `PK_meta` PRIMARY KEY (`fk_filial`, `fk_vendedor`, `fk_cliente_cnpj_cpf`, `fk_produto`, `fk_familia`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `pedido` (
    `nr_pedido_palm` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `nr_pedido_retaguarda` longtext CHARACTER SET utf8mb4 NOT NULL,
    `nr_pedido_cliente` longtext CHARACTER SET utf8mb4 NOT NULL,
    `situacao_pedido` int NOT NULL,
    `data_emissao` date NOT NULL,
    `hora_emissao` time(6) NOT NULL,
    `data_entrega` date NOT NULL,
    `desconto1` double NOT NULL,
    `desconto2` double NOT NULL,
    `desconto3` double NOT NULL,
    `desconto4` double NOT NULL,
    `peso_bruto` double NOT NULL,
    `valor_bruto` double NOT NULL,
    `valor_frete` double NOT NULL,
    `valor_frete_tonelada` double NOT NULL,
    `fk_cliente_cnpj_cpf` int NOT NULL,
    `fk_cond_pgto` int NOT NULL,
    `fk_contato` int NOT NULL,
    `fk_empresa` int NOT NULL,
    `fk_filial` int NOT NULL,
    `fk_end_cobranca` int NOT NULL,
    `fk_end_entrega` int NOT NULL,
    `fk_forma_pgto` int NOT NULL,
    `fk_nat_oper` int NOT NULL,
    `fk_oper_comercial` int NOT NULL,
    `fk_tipo_cobranca` int NOT NULL,
    `fk_tipo_frete` int NOT NULL,
    `fk_transportadora` int NOT NULL,
    `fk_vendedor` int NOT NULL,
    `obs_pedido` longtext CHARACTER SET utf8mb4 NOT NULL,
    `cod_categoria1` longtext CHARACTER SET utf8mb4 NOT NULL,
    `cod_categoria2` longtext CHARACTER SET utf8mb4 NOT NULL,
    `cod_categoria3` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_pedido` PRIMARY KEY (`nr_pedido_palm`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Produto` (
    `codigo` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `descricao` longtext CHARACTER SET utf8mb4 NULL,
    `descricao_produto` longtext CHARACTER SET utf8mb4 NULL,
    `bloqueado` longtext CHARACTER SET utf8mb4 NULL,
    `fk_unidade_medida` longtext CHARACTER SET utf8mb4 NULL,
    `fk_familia` longtext CHARACTER SET utf8mb4 NULL,
    `fk_natureza_operacao` longtext CHARACTER SET utf8mb4 NULL,
    `fk_empresa` int NULL,
    `fk_grade1` int NULL,
    `fk_grade2` int NULL,
    `fk_grade3` int NULL,
    `qtd_embalagem` double NOT NULL,
    `qtd_mult_vendas` double NOT NULL,
    `peso_bruto` double NOT NULL,
    `aliquota_ipi` double NOT NULL,
    `cmv` double NOT NULL,
    CONSTRAINT `PK_Produto` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `propriedades` (
    `nome` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `descricao` longtext CHARACTER SET utf8mb4 NOT NULL,
    `valor` longtext CHARACTER SET utf8mb4 NOT NULL,
    `sequencia` int NOT NULL,
    CONSTRAINT `PK_propriedades` PRIMARY KEY (`nome`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `relclientetabelapreco` (
    `fk_cliente_cpf_cnpj` varchar(14) CHARACTER SET utf8mb4 NOT NULL,
    `fk_empresa` int NOT NULL,
    `fk_filial` int NOT NULL,
    `fk_tabela_preco` varchar(10) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_relclientetabelapreco` PRIMARY KEY (`fk_filial`, `fk_cliente_cpf_cnpj`, `fk_empresa`, `fk_tabela_preco`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `relcondpgtotabpreco` (
    `fk_cliente_cnpj` varchar(14) CHARACTER SET utf8mb4 NOT NULL,
    `fk_condicao_pgto` varchar(10) CHARACTER SET utf8mb4 NOT NULL,
    `fk_empresa` int NOT NULL,
    `fk_filial` int NOT NULL,
    `fk_tabela_preco` varchar(10) CHARACTER SET utf8mb4 NOT NULL,
    `fk_vendedor` varchar(7) CHARACTER SET utf8mb4 NOT NULL,
    `incondicional` longtext CHARACTER SET utf8mb4 NOT NULL,
    `perc_desconto` double NOT NULL,
    CONSTRAINT `PK_relcondpgtotabpreco` PRIMARY KEY (`fk_empresa`, `fk_filial`, `fk_condicao_pgto`, `fk_tabela_preco`, `fk_vendedor`, `fk_cliente_cnpj`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `relfilialcondpgto` (
    `cod_empresa` int NOT NULL,
    `cod_filial` int NOT NULL,
    `cod_condicao` varchar(10) CHARACTER SET utf8mb4 NOT NULL,
    `vlr_minimo` double NOT NULL,
    CONSTRAINT `PK_relfilialcondpgto` PRIMARY KEY (`cod_empresa`, `cod_filial`, `cod_condicao`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `relvendedortabelapreco` (
    `fk_empresa` int NOT NULL,
    `fk_tabela_preco` varchar(10) CHARACTER SET utf8mb4 NOT NULL,
    `fk_vendedor` varchar(7) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_relvendedortabelapreco` PRIMARY KEY (`fk_vendedor`, `fk_empresa`, `fk_tabela_preco`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `situacaopedido` (
    `codigo` int NOT NULL AUTO_INCREMENT,
    `descricao` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_situacaopedido` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `sys_config` (
    `Version` int NOT NULL AUTO_INCREMENT,
    CONSTRAINT `PK_sys_config` PRIMARY KEY (`Version`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `tabelapreco` (
    `codigo` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `fk_empresa` int NOT NULL,
    `descricao` longtext CHARACTER SET utf8mb4 NOT NULL,
    `especial_cliente` longtext CHARACTER SET utf8mb4 NOT NULL,
    `promocional` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_tabelapreco` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `tipocobranca` (
    `codigo` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `fk_empresa` int NOT NULL,
    `descricao` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_tipocobranca` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `titulo` (
    `codigo` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `fk_empresa` int NOT NULL,
    `fk_filial` int NOT NULL,
    `tipo_titulo` longtext CHARACTER SET utf8mb4 NOT NULL,
    `data_vencimento` date NOT NULL,
    `valor_original` double NOT NULL,
    `percentual_juros_dia` double NOT NULL,
    `valor_juros_dia` double NOT NULL,
    `valor_multa` double NOT NULL,
    `fk_cliente_cnpj_cpf` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_titulo` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `transportadora` (
    `codigo` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `descricao` longtext CHARACTER SET utf8mb4 NOT NULL,
    `cnpj` longtext CHARACTER SET utf8mb4 NOT NULL,
    `cidade` longtext CHARACTER SET utf8mb4 NOT NULL,
    `uf` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_transportadora` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `vendedor` (
    `codigo` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `senha` longtext CHARACTER SET utf8mb4 NULL,
    `nome` longtext CHARACTER SET utf8mb4 NULL,
    `email` longtext CHARACTER SET utf8mb4 NULL,
    `tipo` longtext CHARACTER SET utf8mb4 NULL,
    `senha_caixa_postal` longtext CHARACTER SET utf8mb4 NULL,
    `codigo_supervisor` longtext CHARACTER SET utf8mb4 NULL,
    `atualiza_saldoflex` longtext CHARACTER SET utf8mb4 NULL,
    `sys_restore_tablet` int NULL,
    CONSTRAINT `PK_vendedor` PRIMARY KEY (`codigo`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230517155612_First', '6.0.10');

COMMIT;

