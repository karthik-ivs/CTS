let selectedEventIndex = null;

// Welcome Message
console.log("Welcome to the Community Portal");

window.onload = function () {
    alert("Welcome to the Community Event Portal!");
};

// Event Fees
const eventFees = {
    Music: 100,
    Sports: 150,
    Food: 80,
    Dance: 120,
    Art: 90
};

// Event Type Selection
document.getElementById("eventType").onchange = function () {
    const selectedEvent = this.value;

    alert(
        `Selected Event: ${selectedEvent}\nFee: ₹${eventFees[selectedEvent]}`
    );

    localStorage.setItem("preferredEvent", selectedEvent);
};

// Restore Preferred Event
window.addEventListener("load", () => {
    const savedEvent = localStorage.getItem("preferredEvent");

    if (savedEvent) {
        document.getElementById("eventType").value = savedEvent;
    }
});

// Registration Form
document
    .getElementById("registrationForm")
    .addEventListener("submit", function (event) {

        event.preventDefault();

        const name =
            document.getElementById("userName").value;

        const email =
            document.getElementById("userEmail").value;

        if (!name || !email) {

            alert("Please fill all fields");

            return;
        }

        if (selectedEventIndex === null) {

            alert(
                "Please select an event from Upcoming Events first."
            );

            return;
        }

        try {

            if (
                events[selectedEventIndex].seats <= 0
            ) {

                throw new Error(
                    "No seats available."
                );
            }

            events[selectedEventIndex].seats--;

            document
                .getElementById(
                    "registrationOutput"
                )
                .innerHTML =
                `✅ Registration Successful for
                ${events[selectedEventIndex].name}`;

            displayEvents(events);

            this.reset();

            selectedEventIndex = null;

        }
        catch (error) {

            alert(error.message);
        }
    });

// Phone Validation
document.getElementById("phone").onblur = function () {

    const phonePattern = /^[0-9]{10}$/;

    if (!phonePattern.test(this.value)) {
        alert("Please enter a valid 10-digit phone number");
    }
};

// Character Counter
document.getElementById("feedbackText")
    .addEventListener("keyup", function () {

        document.getElementById("charCount").textContent =
            this.value.length;
    });

// Geolocation
document.getElementById("locationBtn")
    .addEventListener("click", () => {

        if (!navigator.geolocation) {
            alert("Geolocation is not supported.");
            return;
        }

        navigator.geolocation.getCurrentPosition(

            function (position) {

                document.getElementById("locationResult").innerHTML =
                    `Latitude: ${position.coords.latitude}
                     <br>
                     Longitude: ${position.coords.longitude}`;
            },

            function (error) {

                document.getElementById("locationResult").innerHTML =
                    error.message;
            },

            {
                enableHighAccuracy: true,
                timeout: 10000
            }
        );
    });

// Warn Before Leaving Page
window.onbeforeunload = function () {
    return "Are you sure you want to leave?";
};

// =======================
// Event Class
// =======================

class Event {

    constructor(name, category, seats) {

        this.name = name;
        this.category = category;
        this.seats = seats;
    }

    checkAvailability() {

        return this.seats > 0
            ? "Available"
            : "Full";
    }
}

// =======================
// Event Array
// =======================

let events = [

    new Event("Music Festival", "Music", 20),

    new Event("Football Tournament", "Sports", 15),

    new Event("Food Carnival", "Food", 10),

    new Event("Rock Concert", "Music", 0)
];

// Push Example
events.push(
    new Event("Community Cricket", "Sports", 25)
);

// =======================
// Display Events
// =======================

function displayEvents(eventList) {

    const container =
        document.getElementById("eventContainer");

    container.innerHTML = "";

    eventList.forEach((eventObj, index) => {

        const card =
            document.createElement("div");

        card.className = "col-md-4 mb-3";

        card.innerHTML = `

            <div class="card h-100 shadow">

                <div class="card-body">

                    <h5>${eventObj.name}</h5>

                    <p>
                        Category:
                        ${eventObj.category}
                    </p>

                    <p>
                        Seats:
                        ${eventObj.seats}
                    </p>

                    <p>
                        Status:
                        ${eventObj.checkAvailability()}
                    </p>

                    <button
                        class="btn btn-primary registerBtn"
                        data-index="${index}">
                        Register
                    </button>

                </div>

            </div>
        `;

        container.appendChild(card);
    });

    attachRegisterEvents();
}

// =======================
// Register Button
// =======================

function attachRegisterEvents() {

    document
        .querySelectorAll(".registerBtn")
        .forEach(button => {

            button.onclick = function () {

                const index =
                    this.dataset.index;

                selectedEventIndex = index;

                // Auto select event
                document.getElementById("eventType").value =
                    events[index].category;

                // Scroll to form
                document
                    .getElementById("register")
                    .scrollIntoView({
                        behavior: "smooth"
                    });
            };
        });
}

// =======================
// Filter Events
// =======================

document
    .getElementById("categoryFilter")
    .addEventListener("change",
        function () {

            const category =
                this.value;

            if (category === "All") {

                displayEvents(events);

                return;
            }

            const filteredEvents =
                events.filter(eventObj =>
                    eventObj.category === category
                );

            displayEvents(filteredEvents);
        }
    );

// Initial Load
displayEvents(events);