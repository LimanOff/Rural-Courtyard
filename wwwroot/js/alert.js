function closeAlert(alertID) {
    var divParent = document.querySelector(`.alert-parent`);
    var divToDelete = divParent.children[alertID]

    if (divParent) {
        divParent.removeChild(divToDelete);

        console.log("Alert with " + alertID + " id was removed.");
    } else {
        console.log("Alert with " + alertID + " id wasn`t found.");
    }
}