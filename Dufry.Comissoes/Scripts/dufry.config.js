
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

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//Configuração do framework de validação
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

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


jQuery.validator.addMethod(
    "custom-combobox-input",
    function (value, element)
    {
        if (element.value === "") {
            return false;
        }
        else {
            return true;
        }
    });


//----------------------------------------------------------------------------

$(function () {
    $(".autocomplete-combobox").combobox();
});

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//Métodos do jqueryui autocomplete combobox
//jqueryui.com/autocomplete/#combobox
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

(function ($) {
    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
              .addClass("custom-combobox")
              .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
              value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
              .appendTo(this.wrapper)
              .val(value)
              //.attr("title", "digite ou selecione")
              .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
              .autocomplete({
                  delay: 0,
                  minLength: 0,
                  source: $.proxy(this, "_source")
              })
              .tooltip({
                  tooltipClass: "ui-state-highlight"
              });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {
            var input = this.input,
              wasOpen = false;

            $("<a>")
              .attr("tabIndex", -1)
              //.attr("title", "Exibir todos os items")
              .attr("title", "")
              .tooltip()
              .appendTo(this.wrapper)
              .button({
                  icons: {
                      primary: "ui-icon-triangle-1-s"
                  },
                  text: false
              })
              .removeClass("ui-corner-all")
              .addClass("custom-combobox-toggle ui-corner-right")
              .mousedown(function () {
                  wasOpen = input.autocomplete("widget").is(":visible");
              })
              .click(function () {
                  input.focus();

                  // Close if already visible
                  if (wasOpen) {
                      return;
                  }

                  // Pass empty string as value to search for, displaying all results
                  input.autocomplete("search", "");
              });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {
                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
              valueLowerCase = value.toLowerCase(),
              valid = false;
            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {
                return;
            }

            // Remove invalid value
            this.input
              .val("")
              //.attr("title", "''" + value + "''" + " não existe na base de dados")
                .attr("title", "")
              .tooltip("open");
            this.element.val("");
            this._delay(function () {
                this.input.tooltip("close").attr("title", "");
            }, 2500);
            this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });
})(jQuery);

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------