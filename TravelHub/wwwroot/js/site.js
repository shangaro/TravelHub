// Write your JavaScript code.


$(document).ready(function() {

    // object used to store and manipulate current page state

    var prevYearCheckBox = $('PrevYearToggle')[0];
    var pageState = {
        value: (function() {
            //one time setup on page load to determine starting state
            var state = $("meta[name='pageState']").attr("content").split("|");
            // return  the current KPI page state
            getKpi: function() {
                if (this.value()[0] === "KPI") return this.value()[1];
                else throw "page state is not currently a KPI";
            }
            getType: function() {
                return this.value()[0];
            }


            // renders page of web app bases on value of ViewBage.PageState
            renderState: function(refresh) {
                $('#LinksPage').hide();
                $('ProcessingAverageSection').hide();
                if (refresh) initFilters();

                switch (this.getType())
                {
                    case "ServiceApp":
                        if (refresh) prevYearCheckbox.checked;

                }

            }
            return function (newState) {
                if (typeof newState === 'undefined') return state;
                var stateIndex = stateIndexOf(newState);
                if (stateIndex === -1) throw "invalid state given: " + newState;
                else {
                    state = newState.split("|");
                    // update meta tage to current state
                    //$("meta[name='pageState']").attr("content", newState);
                    console.log("new state: " + state);
                    this.renderState(true);
                }
            } 
        })
    }

    // inital Setup of Element
    $("#menu").kendoMenu({
        select:onSelect
    });

    $("#allDatePicker").kendoDropDownList({
        dataSource: [
            { Name: "Month to Date", Value: monthToDate },
            {Name:"Year to Date", Value:yearToDate},
        ],
        dataTextField: "Name",
        dataValueField:"Value"
    });
    // sets the default values for all filters
    function initFilters() {
        RegionPicker.select(0);
    }

    function onSelect(e) {
        if ($(e.item).hasClass("jobNumber"))
            pageState.value("ServiceApp");
    }
}