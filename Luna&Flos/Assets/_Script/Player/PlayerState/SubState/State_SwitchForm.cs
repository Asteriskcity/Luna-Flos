using Guagua.WeaponSystem;


namespace Guagua.Nia
{
    public class State_SwitchForm : State_Ability
    {

        private WeaponGenerator weaponGenerator;

        public State_SwitchForm(
            Player player,
            PlayerStateMachine stateMachine,
            PlayerData playerData,
            string animBoolName,
            WeaponGenerator weaponGenerator
        ) : base(player, stateMachine, playerData, animBoolName)
        {
            this.weaponGenerator = weaponGenerator;
            SwitchManager.OnWeaponSwitch += HandleSwitch;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }


        private void HandleSwitch(int index)
        {
            weaponGenerator.GenerateWeapon(Form.weaponBox[index]);
        }


        public override void AnimationFinTrigger()
        {
            base.AnimationFinTrigger();

            isAbilityDone = true;
        }

    }

}

