var submitbutton = document.getElementById('contact-submit');

submitbutton.onclick = function () {

    if (ValidateElememts() == false) {
        return false;
    }

    var formData = {
        Name: document.getElementById('name').value,
        Email: document.getElementById('email').value,
        PhoneNumber: document.getElementById('phone').value,
        Message: document.getElementById('message').value,
        GoogleRecaptchaToken: document.getElementById('googleRecaptchaToken').value
    };

    var submitSuccessMessage = document.getElementById('submitSuccessMessage');
    var submitErrorMessage = document.getElementById('submitErrorMessage');

    fetch("/Feedback/Submit", {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(formData)
    }).then(res => {
        console.log("Request complete! response:", res);
        if (res.status == 200) {
            submitSuccessMessage.classList.remove("d-none");
            submitErrorMessage.classList.add("d-none");
        } else {
            submitErrorMessage.classList.remove("d-none");
            submitSuccessMessage.classList.add("d-none");
        }
    }).catch(err => {
        console.error(err);
        submitErrorMessage.classList.remove("d-none");
        submitSuccessMessage.classList.add("d-none");
    });
}

function ValidateElememts() {
    if (document.getElementById('name').value.trim() == "") {
        document.getElementById('nameValidation').classList.remove("d-none");
        return false;
    } else {
        document.getElementById('nameValidation').classList.add("d-none");
    }

    if (document.getElementById('email').value.trim() == "") {
        document.getElementById('emailValidation').classList.remove("d-none");
        return false;
    } else {
        document.getElementById('emailValidation').classList.add("d-none");
    }
    if (document.getElementById('phone').value.trim() == "") {
        document.getElementById('phoneValidation').classList.remove("d-none");
        return false;
    } else {
        document.getElementById('phoneValidation').classList.add("d-none");
    }    

    if (document.getElementById('message').value.trim() == "") {
        document.getElementById('messageValidation').classList.remove("d-none");
        return false;
    } else {
        document.getElementById('messageValidation').classList.add("d-none");
    }

    if (document.getElementById('googleRecaptchaToken').value.trim() == "") {
        document.getElementById('googleRecaptchaTokenValidation').classList.remove("d-none");
        return false;
    } else {
        document.getElementById('googleRecaptchaTokenValidation').classList.add("d-none");
        return true;
    }
}


var onloadCallback = function () {
    grecaptcha.render('html_element', {
        'sitekey': sitekey,
        'callback': verifyCallback
    });
};

var verifyCallback = function (response) {
    document.getElementById("googleRecaptchaToken").value = response;
};