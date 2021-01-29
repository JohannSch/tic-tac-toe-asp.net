$().ready(() => {
    $(".cellButton").click((e) => {
        e.target.setAttribute('disabled', 'disabled');
    });

    function lockSelectionButtons(itemClass) {
        $(itemClass).css('background-color', 'green');
        $('.computer').attr('disabled', 'disabled');
        $('.person').attr('disabled', 'disabled');
        blockUnblockCells(true);
    }

    $('.person').click((e) => {
        lockSelectionButtons('.person');
    });

    $('.computer').click((e) => {
        lockSelectionButtons('.computer');
        e.target.setAttribute('data-isComputerFirst', '1');
        blockUnblockUnusedCells(false);
        computerGo();
    });

    $('.restart').click((e) => {
        location.reload();
    });

    blockUnblockCells(false);
});
