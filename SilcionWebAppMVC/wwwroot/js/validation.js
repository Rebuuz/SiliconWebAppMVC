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


const formSubmitHandler = async (event) => {
    event.preventDefault(); // Förhindra standard beteende av formulär skickande

    // Utför din validering här
    let isValid = true;
    inputs.forEach(input => {
        // Kör valideringsfunktioner för varje inmatningsfält
        // Om någon av dem returnerar false, sätt isValid till false
    });

    // Om isValid är true, fortsätt att skicka formuläret via AJAX
    if (isValid) {
        try {
            const response = await fetch(event.target.action, {
                method: 'POST',
                body: new FormData(event.target)
            });

            if (response.ok) {
                // Uppdatera nyhetsbrevsdelen med den nya informationen
                const newsletterSection = document.querySelector('.newsletter-section');
                const newNewsletterContent = await response.text();
                newsletterSection.innerHTML = newNewsletterContent;
            } else {
                console.error('Server error:', response.status);
            }
        } catch (error) {
            console.error('Fetch error:', error);
        }
    }
};

forms.forEach(form => {
    form.addEventListener('submit', formSubmitHandler);
});
