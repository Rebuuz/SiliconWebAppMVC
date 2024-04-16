const formErrorHandler = (element, validationResult, ) => {
    console.log(element)
    let spanElement = document.querySelector(`[data-valmsg-for="${element.name}"]`)

    if (validationResult) {
        element.classList.remove('input-validation-error')
        spanElement.classList.remove('field-validation-error')
        spanElement.classList.add('field-validation-valid')
        spanElement.innerHTML = ''
    }
    else {
        element.classList.add('input-validation-error')
        spanElement.classList.add('field-validation-error')
        spanElement.classList.remove('field-validation-valid')
        spanElement.innerHTML = element.dataset.valRequired 
    }
}

const compareValidator = (element, compareValue) => {
    if (element === compareValue)
        return true

    return false
}



const textValidator = (element, minLength = 2) => {
    if (element.value.length >= minLength) {
        formErrorHandler(element, true)
    } else {
        formErrorHandler(element, false)
    }  

}

const emailValidator = (element) => {
    const regEx = /^([A-Za-z0-9_\-.+])+@([A-Za-z0-9_\-.])+\.([A-Za-z]{2,})$/

    formErrorHandler(element, regEx.test(element.value))
}

const passwordValidator = (element) => {

    if (element.dataset.valEqualtoOther !== undefined) {
        let password = document.getElementsByName(element.dataset.valEqualtoOther.replace('*', 'Form'))[0].value

        if (element.value)
            formErrorHandler(element, true)
        else
            formErrorHandler(element, false)
        /*formErrorHandler(element, compareValidator(element.value, document.getElementsByName(element.dataset.valEqualtoOther.replace('*', 'Form' [0].value)))*/
    }
    else {
        const regEx = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?\/\\-]).{8,}$/;
        formErrorHandler(element, regEx.test(element.value))
    }
}

const checkboxValidator = (element) => {
    if (element.checked) {
        formErrorHandler(element, true)
    } else {
        formErrorHandler(element, false)
    }
}

let forms = document.querySelectorAll('form')
let inputs = forms[0].querySelectorAll('input')

inputs.forEach(input => {
    if (input.dataset.val === 'true') {
        if (input.type === 'checkbox') {
            input.addEventListener('change', (e) => {
                checkboxValidator(e.target)
            })
        }
        else {
            input.addEventListener('keyup', () => {
                switch (input.type) {
                    case 'text':
                        textValidator(input)
                        break;
                    case 'email':
                        emailValidator(input)
                        break;
                    case 'password':
                        passwordValidator(input)
                        break;
                }
            })
        }
    }
})

//Extra validation so as to not reload page when trying to submit an empty email form (subscription)
//document.querySelector('form').addEventListener('submit', async function (event) {
//    event.preventDefault(); 

//    let isValid = true;

//    // check whether is is valid
//    inputs.forEach(input => {
//        if (input.dataset.val === 'true') {
//            switch (input.type) {
//                case 'email':
//                    emailValidator(input);
//                    break;
//            }

//            // If it's false - add message
//            if (!input.classList.contains('input-validation-error')) {
//                isValid = false;
//            }
//        }
//    });

//    if (isValid) {
//        // If valid, send the data in the form 
//        const form = event.target;
//        const formData = new FormData(form);

//        try {
//            const response = await fetch(form.action, {
//                method: form.method,
//                body: formData
//            });

//            if (response.ok) {
//                // check in the console whether it is successful or not. A message will be on the page for viewer
//                console.log('Prenumerationen lyckades!');
//            } else {
//                console.error('Fel vid prenumerationsförsök:', response.statusText);
//            }
//        } catch (error) {
//            console.error('Något gick fel:', error);
//        }
//    }
//});


