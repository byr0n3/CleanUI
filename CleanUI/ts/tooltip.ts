window.Tooltip = {
	registerAll() {
		document.querySelectorAll('[popover=\'hint\']').forEach(window.Tooltip.register);
	},
	register(tooltip: HTMLElement) {
		const parent = getTooltipTrigger();
		const identifier = getIdentifier();

		tooltip.style.setProperty('position-anchor', identifier);
		parent.style.setProperty('anchor-name', identifier);

		parent.addEventListener('mouseover', () => tooltip.showPopover());
		parent.addEventListener('mouseout', () => tooltip.hidePopover());
		parent.addEventListener('focus', () => tooltip.showPopover());
		parent.addEventListener('blur', () => tooltip.hidePopover());

		function getTooltipTrigger() {
			let parent = tooltip.parentElement;

			while (!parent || parent.computedStyleMap().get('pointer-events').toString() === 'none') {
				parent = parent.parentElement;
			}

			return parent;
		}

		function getIdentifier() {
			if (parent.id.length != 0) {
				return '--' + parent.id;
			}

			return '--' + (Math.random() + 1).toString(36).substring(2);
		}
	},
	show(id: string) {
		document.getElementById(id)?.showPopover();
	},
	hide(id: string) {
		document.getElementById(id)?.hidePopover();
	},
};

window.addEventListener('DOMContentLoaded', () => window.Tooltip.registerAll());
Blazor.addEventListener('enhancedload', () => window.Tooltip.registerAll());
