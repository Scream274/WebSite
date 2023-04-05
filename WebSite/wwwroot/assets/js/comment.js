document.addEventListener("DOMContentLoaded", () => {

    let postId = parseInt(document.querySelector('.post-Id').innerHTML);
    if (isNaN(postId)) {
        console.error("Post ID was not found");
        return;
    }

    console.log(postId);

    const url = '/comment/GetAllComments';
    try {
        const response = fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: postId.toString()
        }).then((response) => {
            return response.json(); // parse response body as JSON
        }).then((data) => {
            console.log(data); // log response data
        });
        console.log(response);
    } catch (error) {
        console.error('Ошибка:', error);
    }
})