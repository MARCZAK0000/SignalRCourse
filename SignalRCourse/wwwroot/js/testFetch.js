const test1 = document.querySelector("#test1");
const test2 = document.querySelector("#test2");
const test3 = document.querySelector("#test3");


const getInfomrations = async () => {
    try {
        const result = await fetch("https://localhost:7031/basic/GetInformations", {
            method: "GET"
        });

        if (!result.ok) {
            throw new Error("Something went wrong");
        }

        const json = await result.json();

        console.log(json.name)
        test1.innerHTML = json.name;
        test2.innerHTML = json.surname;
        test3.innerHTML = json.email

    } catch (e) {
        console.error(e);
    }
}

getInfomrations();