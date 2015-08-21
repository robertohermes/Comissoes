
$.validator.methods.range = function (value, element, param) {
    var globalizedValue = value.replace(",", ".");
    return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
}

$.validator.methods.number = function (value, element) {
    return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
}


$.datepicker.setDefaults({
    dateFormat: 'dd/mm/yy',
    dayNames: ['Domingo', 'Segunda-feira', 'Terça-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sábado'],
    //dayNamesMin: ['Do', 'Se', 'Te', 'Qa', 'Qi', 'Se', 'Sa'],
    dayNamesMin: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
    dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
    monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
    monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
});

//--------------------------------------
//--------------------------------------
//Configuração do framework de validação
//--------------------------------------
//--------------------------------------

jQuery.extend(jQuery.validator.messages, {
    required: "Campo obrigatório",
    remote: "Please fix this field.",
    email: "Email inválido",
    url: "URL inválida",
    date: "Data inválida",
    dateISO: "Data inválida",
    number: "Use apenas números inteiros",
    decimal: "Número inválido",
    cpf: "Número de CPF inválido",
    digits: "Please enter only digits.",
    creditcard: "Please enter a valid credit card number.",
    equalTo: "Informe o mesmo valor novamente",
    accept: "Please enter a value with a valid extension.",
    maxlength: jQuery.validator.format("O máximo de caracteres permitido é {0}"),
    minlength: jQuery.validator.format("O mínimo de caracteres permitido é {0}"),
    rangelength: jQuery.validator.format("Informe um valor entre {0} e {1}"),
    range: jQuery.validator.format("Informe um valor entre {0} e {1}"),
    max: jQuery.validator.format("Informe um valor menor ou igual à {0}"),
    min: jQuery.validator.format("Informe um valor maior ou igual à {0}")
});

jQuery.validator.addMethod("date", function (value, element) {
  return (value ? moment(value, 'DD/MM/YYYY').isValid() : true);
});

jQuery.validator.addMethod("decimal", function (value, element) {
    return this.optional(element)
        || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:,\d+)?$/.test(value)
        || /^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:\.\d+)?$/.test(value);
});


jQuery.validator.addMethod(
    "DateGt",
    function (value, element, params) {

        if (
            value &&
            params.val() &&
            moment(value, 'DD/MM/YYYY').isValid() &&
            moment(params.val(), 'DD/MM/YYYY').isValid()) {

            return moment(value, 'DD/MM/YYYY').toDate() > moment(params.val(), 'DD/MM/YYYY').toDate();
        }

        return true;
    });


jQuery.validator.addMethod(
    "DateGtEq",
    function (value, element, params) {

        if (
            value &&
            params.val() &&
            moment(value, 'DD/MM/YYYY').isValid() &&
            moment(params.val(), 'DD/MM/YYYY').isValid()) {

            return moment(value, 'DD/MM/YYYY').toDate() >= moment(params.val(), 'DD/MM/YYYY').toDate();
        }

        return true;
    });
