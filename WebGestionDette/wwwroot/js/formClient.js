document.addEventListener('DOMContentLoaded', function() {
    const toggleSwitch = document.getElementById('toggleSwitch');
    const formUser = document.getElementById('formUser'); 

    toggleSwitch.addEventListener('change', function() {
        addUser(toggleSwitch)
    });

    function addUser(toggleSwitch) {
        if (toggleSwitch.checked) {
            formUser.classList.remove('hidden');
        } else {
            formUser.classList.add('hidden');
        }
    }
});