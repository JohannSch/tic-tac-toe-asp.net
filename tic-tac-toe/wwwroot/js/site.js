$().ready(() => {
    $(".cellButton").click((e) => {
        $('#CurrentlyPressedButton').val(
            e.target.getAttribute('data-location'));
    });

    function blockCells(isGameActive) {
        if (isGameActive) {
            $('.cell').children().removeAttr('disabled');
        } else {
            $('.cell').children().attr('disabled', 'disabled');
        }
    }

    function lockSelectionButtons(itemClass) {
        $(itemClass).css('background-color', 'red');
        $('.computer').attr('disabled', 'disabled');
        $('.person').attr('disabled', 'disabled');
        blockCells(true);
    }

    $('.person').click((e) => {
        lockSelectionButtons('.person');
        $('#IsComputerFirst').val(0);
    });

    $('.computer').click((e) => {
        lockSelectionButtons('.computer');
        $('#IsComputerFirst').val(1);
    });

    blockCells(false);
});
