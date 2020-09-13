﻿using RPAQuiz.features.sign_in.contollers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPAQuiz.common

{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<BaseForm, Form>))]
    public abstract class BaseForm : Form
    {
        public abstract BaseController Controller
        {
            get;

        }

        public abstract void ShowMessage(string message);

        public BaseForm()
        {
            SetupFormSettings();
        }

        private void SetupFormSettings()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

    }

    // This class is needed for Visual Studio to generate Design preview to show forms that inherit from BaseForm class. If desginer still fails, restart Visual Studio
    public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
    {
        public AbstractControlDescriptionProvider()
            : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
        {
        }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType == typeof(TAbstract))
                return typeof(TBase);

            return base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType == typeof(TAbstract))
                objectType = typeof(TBase);

            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }

}
