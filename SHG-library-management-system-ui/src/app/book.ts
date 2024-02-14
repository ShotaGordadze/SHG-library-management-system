export class Book {
    image: string;
    name: string;
    subject: string;
    author: string;
    number: number;
    issued: boolean;

    constructor() {
        this.image = "https://www.designforwriters.com/wp-content/uploads/2017/10/design-for-writers-book-cover-tf-2-a-million-to-one.jpg";
        this.name = "Unknown name "
        this.subject = "Unknown subject"
        this.author = "Unknown author";
        this.number = 0;
        this.issued = false;
    }
  }

