using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {

        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterAbout).MinimumLength(3).WithMessage("Hakkında kısmını giriniz");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("En fazla 20 karakter giriniz");
            RuleFor(x => x.WriterTitle).MaximumLength(20).WithMessage("Unvan kısmını boş geçemezsiniz");
        }


    }
}
