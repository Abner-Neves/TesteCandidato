$(document).ready(function () {
    $('#cepInput').change(function () {
        var cep = $(this).val().replace(/\D/g, '');
        if (cep) {
            var validCep = /^[0-9]{8}$/;
            if (validCep.test(cep)) {
                $.ajax({
                    url: `https://viacep.com.br/ws/${cep}/json/`,
                    dataType: "json",
                    success: function (data) {
                        if (data.erro) {
                            alert("CEP inválido. Por favor, tente novamente.");
                            $('#cepInput').focus();
                            return;
                        }
                        $('#logradouroInput').val(data.logradouro);
                        $('#complementoInput').val(data.complemento);
                        $('#bairroInput').val(data.bairro);
                        $('#localidadeInput').val(data.localidade);
                        $('#ufInput').val(data.uf);
                        $('#unidadeInput').val(data.unidade);
                        $('#ibgeInput').val(data.ibge);
                        $('#giaInput').val(data.gia);
                    },
                    error: function () {
                        alert("Erro ao buscar o CEP. Por favor, tente novamente.");
                        $('#cepInput').focus();
                    }
                });
            } else {
                alert("Formato de CEP inválido.");
                $('#cepInput').focus();
            }
        } else {
            alert("Por favor, informe um CEP.");
            $('#cepInput').focus();
        }
    });
});